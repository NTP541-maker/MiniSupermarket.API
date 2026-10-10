using MiniSupermarket.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace MiniSupermarket.API.model
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderDetailId { get; set; }

        public int OrderId { get; set; }
        [JsonIgnore]
        [ForeignKey("OrderId")]
        public virtual Order? Order { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        public int Quantity { get; set; } // Số lượng mua

        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; set; } // Giá bán tại thời điểm mua
    }
}