using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Data;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly SupermarketDbContext _context;

        public ProductsController(SupermarketDbContext context)
        {
            _context = context;
        }

        // 1. Lấy toàn bộ danh sách sản phẩm (kèm theo thông tin danh mục)
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _context.Products
                .Include(p => p.Category) // Nối bảng lấy tên danh mục phong cách Daiso
                .AsNoTracking()
                .ToListAsync();
            return Ok(products);
        }

        // 2. Lấy chi tiết 1 sản phẩm theo ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(p => p.ProductId == id);

            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm trong hệ thống Daiso!" });
            }
            return Ok(product);
        }

        // 3. Tìm kiếm sản phẩm theo tên hoặc mã vạch Barcode (phục vụ quét mã tại quầy)
        [HttpGet("search")]
        public async Task<IActionResult> SearchProducts([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new { message = "Vui lòng nhập từ khóa hoặc mã vạch sản phẩm!" });
            }

            var result = await _context.Products
                .Include(p => p.Category)
                .AsNoTracking()
                .Where(p => p.ProductName.Contains(keyword) || p.Barcode.Contains(keyword))
                .ToListAsync();

            return Ok(result);
        }

        // 4. Thêm mới sản phẩm vào kho
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Kiểm tra xem danh mục (CategoryId) có tồn tại không
            var categoryExists = await _context.Categories.AnyAsync(c => c.CategoryId == newProduct.CategoryId);
            if (!categoryExists)
            {
                return BadRequest(new { message = "Mã danh mục (CategoryId) không tồn tại!" });
            }

            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.ProductId }, newProduct);
        }

        // 5. Cập nhật thông tin và kiểm soát tồn kho sản phẩm
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product updateProduct)
        {
            if (id != updateProduct.ProductId)
            {
                return BadRequest(new { message = "ID sản phẩm không khớp!" });
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần cập nhật!" });
            }

            product.Barcode = updateProduct.Barcode;
            product.ProductName = updateProduct.ProductName;
            product.Price = updateProduct.Price;
            product.StockQuantity = updateProduct.StockQuantity; // Cập nhật số lượng tồn kho tự động
            product.CategoryId = updateProduct.CategoryId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // 6. Xóa sản phẩm khỏi hệ thống
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound(new { message = "Không tìm thấy sản phẩm cần xóa!" });
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}