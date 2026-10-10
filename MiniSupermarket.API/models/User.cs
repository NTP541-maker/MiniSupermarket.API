using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Tên đăng nhập không được để trống!")]
        [StringLength(50, ErrorMessage = "Tên đăng nhập tối đa 50 ký tự.")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Mật khẩu không được để trống!")]
        public string Password { get; set; } = string.Empty; // Lưu ý: Trong thực tế nên mã hóa mật khẩu (như BCrypt/SHA256)

        [StringLength(100)]
        public string FullName { get; set; } = string.Empty; // Họ tên nhân viên/quản lý

        [StringLength(50)]
        public string Role { get; set; } = "Staff"; // Phân quyền: Admin (Quản lý) hoặc Staff (Thu ngân)
    }
}