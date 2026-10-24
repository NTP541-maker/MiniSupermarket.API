using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options)
            : base(options)
        {
        }

        // Khai báo các DbSet đại diện cho các bảng trong SQL Server
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Customer> Customers { get; set; } = null!;
        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderDetail> OrderDetails { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(user => user.UserId);
                entity.Property(user => user.Username).IsRequired().HasMaxLength(50);
                entity.HasIndex(user => user.Username).IsUnique();
                entity.Property(user => user.PasswordHash).IsRequired().HasColumnType("nvarchar(max)");
                entity.Property(user => user.FullName).IsRequired().HasMaxLength(100);
                entity.Property(user => user.Role).IsRequired().HasMaxLength(50);
                entity.Property(user => user.IsActive).HasDefaultValue(true);
            });

            // ---------------------------------------------------------
            // 1. CẤU HÌNH VÀ SEED DATA CHO BẢNG CATEGORIES (7 BẢN GHI)
            // ---------------------------------------------------------
            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Categories");
                entity.HasKey(c => c.CategoryId);
                entity.Property(c => c.CategoryName).IsRequired().HasMaxLength(100);
                entity.HasIndex(c => c.CategoryName).IsUnique();
                entity.Property(c => c.Description).HasMaxLength(255);
            });

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Nhà bếp & nấu ăn", Description = "Dụng cụ nhà bếp, bình chứa và vật dụng tiện ích cho gian bếp" },
                new Category { CategoryId = 2, CategoryName = "Vệ sinh & làm sạch", Description = "Bộ vệ sinh, khăn lau, xà phòng và dụng cụ lau nhà" },
                new Category { CategoryId = 3, CategoryName = "Chăm sóc cá nhân", Description = "Sản phẩm chăm sóc sức khỏe, tóc, cơ thể và cá nhân" },
                new Category { CategoryId = 4, CategoryName = "Đồ gia dụng & lưu trữ", Description = "Hộp đựng, khay lưu trữ và vật dụng gia đình" },
                new Category { CategoryId = 5, CategoryName = "Văn phòng & học tập", Description = "Bút, sổ tay, hộp đựng và phụ kiện học tập" },
                new Category { CategoryId = 6, CategoryName = "Trang trí & nội thất mini", Description = "Đồ trang trí, ánh sáng nhỏ và vật dụng tiểu tiết" },
                new Category { CategoryId = 7, CategoryName = "Mẹ & bé", Description = "Dụng cụ hỗ trợ mẹ và bé, đồ dùng tiện nghi hàng ngày" }
            );

            // ---------------------------------------------------------
            // 2. CẤU HÌNH VÀ SEED DATA CHO BẢNG PRODUCTS (21 BẢN GHI)
            // ---------------------------------------------------------
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Products");
                entity.HasKey(p => p.ProductId);
                entity.Property(p => p.Barcode).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.HasIndex(p => p.Barcode).IsUnique();
                entity.Property(p => p.ProductName).IsRequired().HasMaxLength(150);
                entity.Property(p => p.CostPrice).HasColumnType("decimal(18,2)");
                entity.Property(p => p.SellingPrice).HasColumnType("decimal(18,2)");
                entity.Property(p => p.MinStockLevel).HasDefaultValue(10);
                entity.Property(p => p.Unit).IsRequired().HasMaxLength(20);
                entity.HasCheckConstraint("CK_Products_CostPrice", "[CostPrice] >= 0");
                entity.HasCheckConstraint("CK_Products_SellingPrice", "[SellingPrice] >= 0");
                entity.HasCheckConstraint("CK_Products_StockQuantity", "[StockQuantity] >= 0");
                entity.HasCheckConstraint("CK_Products_MinStockLevel", "[MinStockLevel] >= 0");

                entity.HasOne(p => p.Category)
                      .WithMany(c => c.Products)
                      .HasForeignKey(p => p.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "DS-000001", ProductName = "Bộ dao cắt thực phẩm 3 món", CostPrice = 65000, SellingPrice = 89000, StockQuantity = 18, MinStockLevel = 8, Unit = "Bộ", CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "DS-000002", ProductName = "Bình đựng nước 1.5L", CostPrice = 58000, SellingPrice = 79000, StockQuantity = 24, MinStockLevel = 10, Unit = "Chiếc", CategoryId = 1 },
                new Product { ProductId = 3, Barcode = "DS-000003", ProductName = "Tấm lót nướng chống dính", CostPrice = 32000, SellingPrice = 45000, StockQuantity = 35, MinStockLevel = 12, Unit = "Cái", CategoryId = 1 },
                new Product { ProductId = 4, Barcode = "DS-000004", ProductName = "Bóng đèn LED pin mini", CostPrice = 20000, SellingPrice = 28000, StockQuantity = 40, MinStockLevel = 15, Unit = "Cái", CategoryId = 6 },
                new Product { ProductId = 5, Barcode = "DS-000005", ProductName = "Bộ chổi quét nhà mini", CostPrice = 45000, SellingPrice = 62000, StockQuantity = 28, MinStockLevel = 10, Unit = "Bộ", CategoryId = 2 },
                new Product { ProductId = 6, Barcode = "DS-000006", ProductName = "Khăn lau đa năng 30x30", CostPrice = 15000, SellingPrice = 22000, StockQuantity = 60, MinStockLevel = 20, Unit = "Túi", CategoryId = 2 },
                new Product { ProductId = 7, Barcode = "DS-000007", ProductName = "Bát đựng cơm bằng nhựa", CostPrice = 18000, SellingPrice = 26000, StockQuantity = 50, MinStockLevel = 16, Unit = "Cái", CategoryId = 1 },
                new Product { ProductId = 8, Barcode = "DS-000008", ProductName = "Xà phòng tay khô 250ml", CostPrice = 25000, SellingPrice = 32000, StockQuantity = 48, MinStockLevel = 18, Unit = "Chai", CategoryId = 2 },
                new Product { ProductId = 9, Barcode = "DS-000009", ProductName = "Bộ chổi cọ bồn rửa", CostPrice = 39000, SellingPrice = 52000, StockQuantity = 27, MinStockLevel = 10, Unit = "Bộ", CategoryId = 2 },
                new Product { ProductId = 10, Barcode = "DS-000010", ProductName = "Lược chải tóc mini", CostPrice = 9000, SellingPrice = 15000, StockQuantity = 80, MinStockLevel = 25, Unit = "Cái", CategoryId = 3 },
                new Product { ProductId = 11, Barcode = "DS-000011", ProductName = "Bột tẩy răng dạng tuýp", CostPrice = 26000, SellingPrice = 36000, StockQuantity = 42, MinStockLevel = 15, Unit = "Tuýp", CategoryId = 3 },
                new Product { ProductId = 12, Barcode = "DS-000012", ProductName = "Bọc nẹp tóc và hộp đựng", CostPrice = 12000, SellingPrice = 19000, StockQuantity = 90, MinStockLevel = 25, Unit = "Set", CategoryId = 3 },
                new Product { ProductId = 13, Barcode = "DS-000013", ProductName = "Khay đựng mỹ phẩm", CostPrice = 35000, SellingPrice = 48000, StockQuantity = 32, MinStockLevel = 12, Unit = "Cái", CategoryId = 4 },
                new Product { ProductId = 14, Barcode = "DS-000014", ProductName = "Hộp đựng đồ văn phòng", CostPrice = 42000, SellingPrice = 60000, StockQuantity = 26, MinStockLevel = 10, Unit = "Cái", CategoryId = 4 },
                new Product { ProductId = 15, Barcode = "DS-000015", ProductName = "Bút gel 0.5mm", CostPrice = 12000, SellingPrice = 18000, StockQuantity = 70, MinStockLevel = 25, Unit = "Chiếc", CategoryId = 5 },
                new Product { ProductId = 16, Barcode = "DS-000016", ProductName = "Sổ tay mini A6", CostPrice = 18000, SellingPrice = 26000, StockQuantity = 55, MinStockLevel = 18, Unit = "Cuốn", CategoryId = 5 },
                new Product { ProductId = 17, Barcode = "DS-000017", ProductName = "Dây khóa kéo & túi zip", CostPrice = 16000, SellingPrice = 23000, StockQuantity = 60, MinStockLevel = 20, Unit = "Set", CategoryId = 4 },
                new Product { ProductId = 18, Barcode = "DS-000018", ProductName = "Bình đựng thuốc nhỏ", CostPrice = 28000, SellingPrice = 39000, StockQuantity = 22, MinStockLevel = 9, Unit = "Chiếc", CategoryId = 7 },
                new Product { ProductId = 19, Barcode = "DS-000019", ProductName = "Bộ đồ chơi rèn luyện cơ tay", CostPrice = 26000, SellingPrice = 38000, StockQuantity = 20, MinStockLevel = 8, Unit = "Set", CategoryId = 7 },
                new Product { ProductId = 20, Barcode = "DS-000020", ProductName = "Đèn pin mini USB", CostPrice = 68000, SellingPrice = 92000, StockQuantity = 18, MinStockLevel = 8, Unit = "Chiếc", CategoryId = 6 },
                new Product { ProductId = 21, Barcode = "DS-000021", ProductName = "Bộ 3 hộp nhựa đựng thực phẩm", CostPrice = 28000, SellingPrice = 39000, StockQuantity = 30, MinStockLevel = 12, Unit = "Bộ", CategoryId = 4 }
            );

            // ---------------------------------------------------------
            // 3. CẤU HÌNH VÀ SEED DATA CHO BẢNG CUSTOMERS (16 BẢN GHI)
            // ---------------------------------------------------------
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");
                entity.HasKey(c => c.CustomerId);
                entity.Property(c => c.CustomerName).IsRequired().HasMaxLength(100);
                entity.Property(c => c.PhoneNumber).IsRequired().HasMaxLength(15).IsUnicode(false);
                entity.HasIndex(c => c.PhoneNumber).IsUnique();
                entity.Property(c => c.Address).HasMaxLength(200);
                entity.Property(c => c.RewardPoints).HasDefaultValue(0);
                entity.Property(c => c.MembershipRank).HasMaxLength(50).HasDefaultValue("Chuẩn");
            });

            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Minh Anh", PhoneNumber = "0900000001", Address = "Ấp 1, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 25, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 2, CustomerName = "Trần Quốc Bảo", PhoneNumber = "0900000002", Address = "Ấp 2, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 85, MembershipRank = "Bạc" },
                new Customer { CustomerId = 3, CustomerName = "Lê Thị Ngọc", PhoneNumber = "0900000003", Address = "Ấp 3, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 15, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 4, CustomerName = "Phạm Thanh Tùng", PhoneNumber = "0900000004", Address = "Ấp 4, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 240, MembershipRank = "Vàng" },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Thu Hà", PhoneNumber = "0900000005", Address = "Ấp 5, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 60, MembershipRank = "Bạc" },
                new Customer { CustomerId = 6, CustomerName = "Võ Thành Đạt", PhoneNumber = "0900000006", Address = "Ấp 6, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 320, MembershipRank = "Vàng" },
                new Customer { CustomerId = 7, CustomerName = "Đặng Mỹ Linh", PhoneNumber = "0900000007", Address = "Khu dân cư An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 0, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 8, CustomerName = "Bùi Văn Hùng", PhoneNumber = "0900000008", Address = "Ấp 1, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 120, MembershipRank = "Bạc" },
                new Customer { CustomerId = 9, CustomerName = "Đỗ Thị Mai", PhoneNumber = "0900000009", Address = "Ấp 2, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 45, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 10, CustomerName = "Ngô Quốc Khánh", PhoneNumber = "0900000010", Address = "Ấp 3, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 0, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 11, CustomerName = "Dương Khánh Vy", PhoneNumber = "0900000011", Address = "Ấp 4, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 450, MembershipRank = "Vàng" },
                new Customer { CustomerId = 12, CustomerName = "Lý Minh Triết", PhoneNumber = "0900000012", Address = "Ấp 5, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 90, MembershipRank = "Bạc" },
                new Customer { CustomerId = 13, CustomerName = "Phan Thùy Trang", PhoneNumber = "0900000013", Address = "Ấp 6, xã An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 180, MembershipRank = "Bạc" },
                new Customer { CustomerId = 14, CustomerName = "Vũ Hải Đăng", PhoneNumber = "0900000014", Address = "Khu dân cư An Phước, huyện Long Thành, Đồng Nai", RewardPoints = 25, MembershipRank = "Chuẩn" },
                new Customer { CustomerId = 15, CustomerName = "Trịnh Xuân Trường", PhoneNumber = "0900000015", Address = "Xã Long Đức, huyện Long Thành, Đồng Nai", RewardPoints = 280, MembershipRank = "Vàng" },
                new Customer { CustomerId = 16, CustomerName = "Nguyễn Ngọc Ánh", PhoneNumber = "0900000016", Address = "Thị trấn Long Thành, huyện Long Thành, Đồng Nai", RewardPoints = 510, MembershipRank = "Bạch Kim" }
            );

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");
                entity.HasKey(o => o.OrderId);
                entity.Property(o => o.OrderCode).IsRequired().HasMaxLength(50).IsUnicode(false);
                entity.HasIndex(o => o.OrderCode).IsUnique();
                entity.Property(o => o.CreatedDate).HasColumnType("datetime").HasDefaultValueSql("GETDATE()");
                entity.Property(o => o.CashierUsername).IsRequired().HasMaxLength(50);
                entity.Property(o => o.FinalAmount).HasColumnType("decimal(18,2)");
                entity.Property(o => o.RewardPoints).HasDefaultValue(0);
                entity.HasOne(o => o.Customer)
                    .WithMany()
                    .HasForeignKey(o => o.CustomerId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderCode = "AP-HD-20261016-001", CreatedDate = new DateTime(2026, 10, 16, 9, 12, 0), CashierUsername = "cashier01", CustomerId = 1, TotalItems = 3, FinalAmount = 30000, RewardPoints = 3 },
                new Order { OrderId = 2, OrderCode = "AP-HD-20261016-002", CreatedDate = new DateTime(2026, 10, 16, 10, 35, 0), CashierUsername = "cashier01", CustomerId = 3, TotalItems = 5, FinalAmount = 54000, RewardPoints = 5 },
                new Order { OrderId = 3, OrderCode = "AP-HD-20261016-003", CreatedDate = new DateTime(2026, 10, 16, 11, 5, 0), CashierUsername = "cashier02", CustomerId = 4, TotalItems = 3, FinalAmount = 241000, RewardPoints = 24 }
            );

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetails");
                entity.HasKey(d => d.OrderDetailId);
                entity.Property(d => d.UnitPrice).HasColumnType("decimal(18,2)");
                entity.Property(d => d.LineTotal).HasColumnType("decimal(18,2)");
                entity.HasCheckConstraint("CK_OrderDetails_Quantity", "[Quantity] > 0");
                entity.HasOne(d => d.Order)
                    .WithMany(o => o.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 12000, LineTotal = 24000 },
                new OrderDetail { OrderDetailId = 2, OrderId = 1, ProductId = 10, Quantity = 1, UnitPrice = 6000, LineTotal = 6000 },
                new OrderDetail { OrderDetailId = 3, OrderId = 2, ProductId = 13, Quantity = 4, UnitPrice = 4500, LineTotal = 18000 },
                new OrderDetail { OrderDetailId = 4, OrderId = 2, ProductId = 7, Quantity = 1, UnitPrice = 36000, LineTotal = 36000 },
                new OrderDetail { OrderDetailId = 5, OrderId = 3, ProductId = 14, Quantity = 1, UnitPrice = 165000, LineTotal = 165000 },
                new OrderDetail { OrderDetailId = 6, OrderId = 3, ProductId = 18, Quantity = 2, UnitPrice = 38000, LineTotal = 76000 }
            );
        }
    }
}