using MiniSupermarket.API.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MiniSupermarket.API.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string CategoryName { get; set; }

        // Thuộc tính Description mà trình biên dịch đang báo thiếu
        [StringLength(255)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;

        // Mối quan hệ 1-N với Product
        public ICollection<Product>? Products { get; set; }
    }
}