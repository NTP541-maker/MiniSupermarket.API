using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public OrdersController(SupermarketDbContext context)
        {
            _context = context;
        }

        // POST /api/orders
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderCreateDto orderDto)
        {
            if (orderDto == null || orderDto.Items == null || orderDto.Items.Count == 0)
            {
                return BadRequest(new { message = "Dữ liệu đơn hàng không hợp lệ!" });
            }

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                var order = new Order
                {
                    CustomerId = orderDto.CustomerId,
                    OrderDate = DateTime.Now,
                    TotalAmount = orderDto.TotalAmount,
                    PaymentStatus = "Paid",
                    PaymentMethod = orderDto.PaymentMethod ?? "Cash",
                    OrderDetails = new List<OrderDetail>()
                };

                foreach (var item in orderDto.Items)
                {
                    var product = await _context.Products.FindAsync(item.ProductId);
                    if (product == null)
                    {
                        return BadRequest(new { message = $"Không tìm thấy sản phẩm có mã ID: {item.ProductId}" });
                    }

                    if (product.StockQuantity < item.Quantity)
                    {
                        return BadRequest(new { message = $"Sản phẩm '{product.ProductName}' không đủ hàng trong kho (Còn lại: {product.StockQuantity})" });
                    }

                    // 1. Tự động trừ tồn kho
                    product.StockQuantity -= item.Quantity;

                    // 2. Thêm vào chi tiết đơn hàng
                    order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = item.ProductId,
                        Quantity = item.Quantity,
                        UnitPrice = item.UnitPrice
                    });

                    // 3. Tự động ghi nhận log xuất kho (Kiểm soát kho tự động)
                    _context.InventoryLogs.Add(new InventoryLog
                    {
                        ProductId = product.ProductId,
                        TransactionType = "EXPORT",
                        QuantityChange = -item.Quantity,
                        TransactionDate = DateTime.Now,
                        Note = "Xuất bán hàng tự động qua POS"
                    });
                }

                _context.Orders.Add(order);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { success = true, message = "Thanh toán thành công và đã cập nhật tồn kho tự động!", orderId = order.OrderId });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { message = "Lỗi hệ thống khi thanh toán: " + ex.Message });
            }
        }
    }

    // Các DTO hỗ trợ nhận dữ liệu từ Client gửi lên
    public class OrderCreateDto
    {
        public int? CustomerId { get; set; }
        public decimal TotalAmount { get; set; }
        public string? PaymentMethod { get; set; }
        public List<OrderItemDto> Items { get; set; } = new List<OrderItemDto>();
    }

    public class OrderItemDto
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
    }
}