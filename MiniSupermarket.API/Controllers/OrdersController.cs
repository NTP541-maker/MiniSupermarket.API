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

        // 1. Lấy lịch sử tất cả các hóa đơn bán hàng
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .AsNoTracking()
                .ToListAsync();
            return Ok(orders);
        }

        // 2. Lấy chi tiết 1 hóa đơn theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _context.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(od => od.Product)
                .FirstOrDefaultAsync(o => o.OrderId == id);

            if (order == null)
            {
                return NotFound(new { message = "Không tìm thấy hóa đơn thanh toán!" });
            }
            return Ok(order);
        }

        // 3. TẠO HÓA ĐƠN BÁN HÀNG & TỰ ĐỘNG TRỪ TỒN KHO
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] Order orderDto)
        {
            if (orderDto.OrderDetails == null || !orderDto.OrderDetails.Any())
            {
                return BadRequest(new { message = "Hóa đơn phải có ít nhất một sản phẩm!" });
            }

            decimal calculatedTotal = 0;

            // Kiểm tra tồn kho và tính toán tổng tiền
            foreach (var detail in orderDto.OrderDetails)
            {
                var product = await _context.Products.FindAsync(detail.ProductId);
                if (product == null)
                {
                    return BadRequest(new { message = $"Sản phẩm với ID {detail.ProductId} không tồn tại trong kho!" });
                }

                // Kiểm tra xem số lượng tồn kho có đủ bán không
                if (product.StockQuantity < detail.Quantity)
                {
                    return BadRequest(new { message = $"Sản phẩm '{product.ProductName}' không đủ hàng trong kho (Còn lại: {product.StockQuantity})" });
                }

                // Tự động trừ tồn kho
                product.StockQuantity -= detail.Quantity;

                // Gán giá chuẩn từ sản phẩm vào chi tiết hóa đơn
                detail.UnitPrice = product.Price;
                calculatedTotal += detail.UnitPrice * detail.Quantity;
            }

            orderDto.TotalAmount = calculatedTotal;
            orderDto.OrderDate = DateTime.Now;

            _context.Orders.Add(orderDto);
            await _context.SaveChangesAsync(); // Lưu hóa đơn và cập nhật kho vào SQL Server

            return CreatedAtAction(nameof(GetOrderById), new { id = orderDto.OrderId }, orderDto);
        }
    }
}