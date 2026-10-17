using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniSupermarket.API.Models
{
    [Table("InventoryLogs")]
    public class InventoryLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product? Product { get; set; }

        [Required]
        [StringLength(20)]
        public string TransactionType { get; set; } = string.Empty; // IMPORT / EXPORT / ADJUST

        public int QuantityChange { get; set; }

        public DateTime TransactionDate { get; set; }

        [StringLength(50)]
        public string? BatchNumber { get; set; }

        public DateTime? ExpirationDate { get; set; }

        [StringLength(255)]
        public string? Note { get; set; }

        public int? SupplierId { get; set; }

        [ForeignKey("SupplierId")]
        public virtual Supplier? Supplier { get; set; }
    }
}