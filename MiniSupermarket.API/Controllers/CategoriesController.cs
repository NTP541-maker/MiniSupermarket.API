using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniSupermarket.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniSupermarket.API.Controllers
{
    // Đường dẫn chung:
    // /api/categories
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriesController : ControllerBase
    {
        // =====================================================
        // DỮ LIỆU MẪU
        // Lưu tạm trên RAM
        // =====================================================

        private static readonly List<Category> _categories = new()
        {
            new Category
            {
                CategoryId = 1,
                CategoryName = "Bánh kẹo & Đồ ăn vặt",
                Description = "Snack, bánh quy, kẹo dẻo"
            },

            new Category
            {
                CategoryId = 2,
                CategoryName = "Nước giải khát & Trà",
                Description = "Nước ngọt, nước khoáng, trà"
            },

            new Category
            {
                CategoryId = 3,
                CategoryName = "Sữa & Sản phẩm từ sữa",
                Description = "Sữa tươi, sữa chua, phô mai"
            },

            new Category
            {
                CategoryId = 4,
                CategoryName = "Mì gói & Thực phẩm ăn liền",
                Description = "Mì ăn liền, phở khô, cháo gói"
            },

            new Category
            {
                CategoryId = 5,
                CategoryName = "Gia vị & Dầu ăn",
                Description = "Nước mắm, hạt nêm, dầu thực vật"
            }
        };


        // =====================================================
        // 1. XEM TẤT CẢ NHÓM HÀNG
        // GET: /api/categories
        //
        // Admin: được
        // Cashier: được
        // =====================================================

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_categories);
        }


        // =====================================================
        // 2. XEM CHI TIẾT NHÓM HÀNG
        // GET: /api/categories/{id}
        //
        // Admin: được
        // Cashier: được
        // =====================================================

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var category = _categories
                .FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng!"
                });
            }

            return Ok(category);
        }


        // =====================================================
        // 3. TÌM KIẾM NHÓM HÀNG
        // GET: /api/categories/search?keyword=...
        //
        // Admin: được
        // Cashier: được
        // =====================================================

        [HttpGet("search")]
        public IActionResult Search([FromQuery] string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest(new
                {
                    message = "Vui lòng nhập từ khóa!"
                });
            }

            var result = _categories
                .Where(c =>
                    c.CategoryName.Contains(
                        keyword,
                        StringComparison.OrdinalIgnoreCase))
                .ToList();

            return Ok(result);
        }


        // =====================================================
        // 4. THÊM NHÓM HÀNG
        // POST: /api/categories
        //
        // CHỈ ADMIN ĐƯỢC THỰC HIỆN
        // =====================================================

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create([FromBody] Category newCategory)
        {
            // Kiểm tra dữ liệu
            if (newCategory == null)
            {
                return BadRequest(new
                {
                    message = "Dữ liệu không hợp lệ!"
                });
            }

            // Kiểm tra tên nhóm hàng
            if (string.IsNullOrWhiteSpace(newCategory.CategoryName))
            {
                return BadRequest(new
                {
                    message = "Tên nhóm hàng không được để trống!"
                });
            }

            // Tạo ID mới
            int newId = _categories.Count > 0
                ? _categories.Max(c => c.CategoryId) + 1
                : 1;

            newCategory.CategoryId = newId;

            // Thêm vào danh sách
            _categories.Add(newCategory);

            // Trả về 201 Created
            return CreatedAtAction(
                nameof(GetById),
                new
                {
                    id = newCategory.CategoryId
                },
                newCategory);
        }


        // =====================================================
        // 5. SỬA NHÓM HÀNG
        // PUT: /api/categories/{id}
        //
        // CHỈ ADMIN ĐƯỢC THỰC HIỆN
        // =====================================================

        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Update(
            int id,
            [FromBody] Category updateCategory)
        {
            // Kiểm tra dữ liệu
            if (updateCategory == null)
            {
                return BadRequest(new
                {
                    message = "Dữ liệu không hợp lệ!"
                });
            }

            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(updateCategory.CategoryName))
            {
                return BadRequest(new
                {
                    message = "Tên nhóm hàng không được để trống!"
                });
            }

            // Tìm nhóm hàng
            var category = _categories
                .FirstOrDefault(c => c.CategoryId == id);

            if (category == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng cần sửa!"
                });
            }

            // Cập nhật thông tin
            category.CategoryName =
                updateCategory.CategoryName;

            category.Description =
                updateCategory.Description;

            // Thành công
            return Ok(new
            {
                message = "Cập nhật nhóm hàng thành công!",
                data = category
            });
        }


        // =====================================================
        // 6. XÓA NHÓM HÀNG
        // DELETE: /api/categories/{id}
        //
        // CHỈ ADMIN ĐƯỢC THỰC HIỆN
        // =====================================================

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            // Tìm nhóm hàng
            var category = _categories
                .FirstOrDefault(c => c.CategoryId == id);

            // Không tìm thấy
            if (category == null)
            {
                return NotFound(new
                {
                    message = "Không tìm thấy nhóm hàng cần xóa!"
                });
            }

            // Xóa
            _categories.Remove(category);

            return Ok(new
            {
                message = "Xóa nhóm hàng thành công!"
            });
        }


        // =====================================================
        // 7. KIỂM TRA QUYỀN ADMIN
        // GET: /api/categories/admin-dashboard
        //
        // CHỈ ADMIN
        // =====================================================

        [HttpGet("admin-dashboard")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetAdminDashboard()
        {
            return Ok(new
            {
                message =
                    "Chào mừng Admin! Bạn có toàn quyền quản trị hệ thống siêu thị mini."
            });
        }


        // =====================================================
        // 8. KIỂM TRA QUYỀN NHÂN VIÊN
        // GET: /api/categories/staff-pos
        //
        // ADMIN + CASHIER
        // =====================================================

        [HttpGet("staff-pos")]
        [Authorize(Roles = "Admin,Cashier")]
        public IActionResult GetStaffPos()
        {
            return Ok(new
            {
                message =
                    "Màn hình POS Thu ngân sẵn sàng phục vụ bán hàng."
            });
        }
    }
}