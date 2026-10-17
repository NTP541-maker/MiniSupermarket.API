using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options)
        {
        }

        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<InventoryLog> InventoryLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Hộp nhựa chịu nhiệt", Barcode = "8930000000001", Price = 40000m, StockQuantity = 50, CategoryId = 5 },
                new Product { ProductId = 2, ProductName = "Băng dính Washi Tape", Barcode = "8930000000002", Price = 40000m, StockQuantity = 60, CategoryId = 2 },
                new Product { ProductId = 3, ProductName = "Khăn lau Microfiber", Barcode = "8930000000003", Price = 40000m, StockQuantity = 40, CategoryId = 3 },
                new Product { ProductId = 4, ProductName = "Bộ muỗng nĩa inox", Barcode = "8930000000004", Price = 40000m, StockQuantity = 50, CategoryId = 1 },
                new Product { ProductId = 5, ProductName = "Bình giữ nhiệt mini", Barcode = "8930000000005", Price = 40000m, StockQuantity = 35, CategoryId = 5 },
                new Product { ProductId = 6, ProductName = "Sổ tay kẻ ngang", Barcode = "8930000000006", Price = 40000m, StockQuantity = 45, CategoryId = 2 },
                new Product { ProductId = 7, ProductName = "Bông tẩy trang", Barcode = "8930000000007", Price = 40000m, StockQuantity = 30, CategoryId = 4 },
                new Product { ProductId = 8, ProductName = "Dao gọt trái cây", Barcode = "8930000000008", Price = 40000m, StockQuantity = 25, CategoryId = 1 },
                new Product { ProductId = 9, ProductName = "Hộp cơm Bento", Barcode = "8930000000009", Price = 40000m, StockQuantity = 50, CategoryId = 1 },
                new Product { ProductId = 10, ProductName = "Màng bọc thực phẩm", Barcode = "8930000000010", Price = 40000m, StockQuantity = 40, CategoryId = 1 },
                new Product { ProductId = 11, ProductName = "Rổ nhựa đa năng", Barcode = "8930000000011", Price = 40000m, StockQuantity = 30, CategoryId = 5 },
                new Product { ProductId = 12, ProductName = "Bút bi mực gel", Barcode = "8930000000012", Price = 40000m, StockQuantity = 25, CategoryId = 2 },
                new Product { ProductId = 13, ProductName = "Kéo văn phòng", Barcode = "8930000000013", Price = 40000m, StockQuantity = 40, CategoryId = 2 },
                new Product { ProductId = 14, ProductName = "Thú bông móc khóa", Barcode = "8930000000014", Price = 40000m, StockQuantity = 30, CategoryId = 6 },
                new Product { ProductId = 15, ProductName = "Nước rửa chén sinh học", Barcode = "8930000000015", Price = 40000m, StockQuantity = 20, CategoryId = 3 }
            );
            // 1. Dữ liệu mẫu Thương hiệu (Chuyển sang phong cách hàng tiêu dùng Nhật Bản / Daiso)
            modelBuilder.Entity<Brand>().HasData(
                new Brand { BrandId = 1, BrandName = "Daiso Original", OriginRegion = "Nhật Bản", Description = "Sản phẩm tiện ích độc quyền Daiso" },
                new Brand { BrandId = 2, BrandName = "Sanada", OriginRegion = "Nhật Bản", Description = "Đồ nhựa gia dụng cao cấp Nhật Bản" },
                new Brand { BrandId = 3, BrandName = "Inomata", OriginRegion = "Nhật Bản", Description = "Đồ dùng nhà bếp thông minh" },
                new Brand { BrandId = 4, BrandName = "Kowa", OriginRegion = "Nhật Bản", Description = "Dụng cụ vệ sinh & chăm sóc nhà cửa" },
                new Brand { BrandId = 5, BrandName = "Kokuyo", OriginRegion = "Nhật Bản", Description = "Văn phòng phẩm chất lượng cao" },
                new Brand { BrandId = 6, BrandName = "Pentel", OriginRegion = "Nhật Bản", Description = "Bút viết và họa phẩm" },
                new Brand { BrandId = 7, BrandName = "NT Cutter", OriginRegion = "Nhật Bản", Description = "Dao rọc giấy và dụng cụ cắt" },
                new Brand { BrandId = 8, BrandName = "Ebisu", OriginRegion = "Nhật Bản", Description = "Chăm sóc cá nhân & bàn chải đánh răng" },
                new Brand { BrandId = 9, BrandName = "Lion", OriginRegion = "Nhật Bản", Description = "Hóa mỹ phẩm & tẩy rửa" },
                new Brand { BrandId = 10, BrandName = "Sunlemon", OriginRegion = "Nhật Bản", Description = "Thú bông & quà tặng dễ thương" },
                new Brand { BrandId = 11, BrandName = "Kai", OriginRegion = "Nhật Bản", Description = "Dụng cụ nhà bếp & làm móng" },
                new Brand { BrandId = 12, BrandName = "Seria Style", OriginRegion = "Nhật Bản", Description = "Phụ kiện trang trí phong cách Nhật" },
                new Brand { BrandId = 13, BrandName = "Yamada", OriginRegion = "Nhật Bản", Description = "Hộp đựng và tổ chức không gian" },
                new Brand { BrandId = 14, BrandName = "Asvel", OriginRegion = "Nhật Bản", Description = "Bình nước & hộp đựng thực phẩm" },
                new Brand { BrandId = 15, BrandName = "Skater", OriginRegion = "Nhật Bản", Description = "Đồ dùng bento & hộp cơm" }
            );

            // 2. Dữ liệu mẫu Khách hàng
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, CustomerName = "Nguyễn Văn An", PhoneNumber = "0901111111", Address = "Quận 1, TP. HCM", RewardPoints = 120, MembershipRank = "Gold" },
                new Customer { CustomerId = 2, CustomerName = "Trần Thị Bình", PhoneNumber = "0902222222", Address = "Quận 3, TP. HCM", RewardPoints = 50, MembershipRank = "Silver" },
                new Customer { CustomerId = 3, CustomerName = "Lê Hoàng Cường", PhoneNumber = "0903333333", Address = "Quận 5, TP. HCM", RewardPoints = 200, MembershipRank = "Platinum" },
                new Customer { CustomerId = 4, CustomerName = "Phạm Thị Dung", PhoneNumber = "0904444444", Address = "Quận 7, TP. HCM", RewardPoints = 10, MembershipRank = "Bronze" },
                new Customer { CustomerId = 5, CustomerName = "Hoàng Văn Em", PhoneNumber = "0905555555", Address = "Quận 10, TP. HCM", RewardPoints = 80, MembershipRank = "Silver" },
                new Customer { CustomerId = 6, CustomerName = "Vũ Thị Phương", PhoneNumber = "0906666666", Address = "Quận Gò Vấp, TP. HCM", RewardPoints = 150, MembershipRank = "Gold" },
                new Customer { CustomerId = 7, CustomerName = "Đỗ Minh Giang", PhoneNumber = "0907777777", Address = "Quận Tân Bình, TP. HCM", RewardPoints = 30, MembershipRank = "Bronze" },
                new Customer { CustomerId = 8, CustomerName = "Bùi Thanh Hằng", PhoneNumber = "0908888888", Address = "Quận Bình Thạnh, TP. HCM", RewardPoints = 90, MembershipRank = "Silver" },
                new Customer { CustomerId = 9, CustomerName = "Ngô Văn Hùng", PhoneNumber = "0909999999", Address = "TP. Thủ Đức, TP. HCM", RewardPoints = 220, MembershipRank = "Platinum" },
                new Customer { CustomerId = 10, CustomerName = "Dương Thị Kim", PhoneNumber = "0901010101", Address = "Quận 4, TP. HCM", RewardPoints = 40, MembershipRank = "Bronze" },
                new Customer { CustomerId = 11, CustomerName = "Lý Văn Long", PhoneNumber = "0901212121", Address = "Quận 11, TP. HCM", RewardPoints = 110, MembershipRank = "Gold" },
                new Customer { CustomerId = 12, CustomerName = "Đặng Thị Mai", PhoneNumber = "0901313131", Address = "Quận 12, TP. HCM", RewardPoints = 60, MembershipRank = "Silver" },
                new Customer { CustomerId = 13, CustomerName = "Hồ Văn Nam", PhoneNumber = "0901414141", Address = "Hóc Môn, TP. HCM", RewardPoints = 180, MembershipRank = "Gold" },
                new Customer { CustomerId = 14, CustomerName = "Trương Thị Oanh", PhoneNumber = "0901515151", Address = "Củ Chi, TP. HCM", RewardPoints = 20, MembershipRank = "Bronze" },
                new Customer { CustomerId = 15, CustomerName = "Phan Văn Phúc", PhoneNumber = "0901616161", Address = "Bình Chánh, TP. HCM", RewardPoints = 130, MembershipRank = "Gold" }
            );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Đồ dùng nhà bếp", Description = "Dụng cụ nấu ăn, hộp đựng thực phẩm", IsActive = true },
                new Category { CategoryId = 2, CategoryName = "Văn phòng phẩm", Description = "Bút, sổ tay, dụng cụ học tập", IsActive = true },
                new Category { CategoryId = 3, CategoryName = "Vệ sinh nhà cửa", Description = "Dụng cụ dọn dẹp, chất tẩy rửa", IsActive = true },
                new Category { CategoryId = 4, CategoryName = "Chăm sóc cá nhân", Description = "Làm đẹp, mỹ phẩm, sức khỏe", IsActive = true },
                new Category { CategoryId = 5, CategoryName = "Đồ gia dụng & Lưu trữ", Description = "Hộp đựng, rổ nhựa, đồ dùng phòng khách", IsActive = true },
                new Category { CategoryId = 6, CategoryName = "Quà tặng & Phụ kiện", Description = "Thú bông, móc khóa, đồ trang trí", IsActive = true }
            );

            // 3. Dữ liệu mẫu Nhà cung cấp (Chuyên hàng Nhật Bản & Phân phối nội địa)
            modelBuilder.Entity<Supplier>().HasData(
                new Supplier { SupplierId = 1, SupplierName = "Công ty TNHH Nhập khẩu Daiso Việt Nam", ContactName = "Nguyễn Hoàng Nam", PhoneNumber = "0902000001", Address = "KCN Tân Bình, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 2, SupplierName = "Nhà phân phối Sanada Japan", ContactName = "Trần Minh Hà", PhoneNumber = "0902000002", Address = "Q. Bình Thạnh, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 3, SupplierName = "Công ty TNHH Inomata VN", ContactName = "Lê Quốc Thắng", PhoneNumber = "0902000003", Address = "Q.12, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 4, SupplierName = "Kokuyo Vietnam Trading", ContactName = "Phạm Ngọc Lan", PhoneNumber = "0902000004", Address = "Q.7, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 5, SupplierName = "Công ty Thương mại Kai Japan", ContactName = "Vũ Thanh Sơn", PhoneNumber = "0902000005", Address = "Bình Dương", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 6, SupplierName = "Tokyo Lifestyle Supply", ContactName = "Ngô Văn A", PhoneNumber = "0902000006", Address = "Q.1, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 7, SupplierName = "Lion Corporation VN", ContactName = "Lê Thị B", PhoneNumber = "0902000007", Address = "Q.3, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 8, SupplierName = "Asvel Vietnam Import", ContactName = "André Rossi", PhoneNumber = "0902000008", Address = "Hải Phòng", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 9, SupplierName = "Skater Bento House", ContactName = "Trương Văn C", PhoneNumber = "0902000009", Address = "Bình Dương", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 10, SupplierName = "Yamada Household Goods", ContactName = "Đỗ Thị D", PhoneNumber = "0902000010", Address = "Gò Vấp, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 11, SupplierName = "Global Japan Trade", ContactName = "Trương Văn E", PhoneNumber = "0902000011", Address = "Q.5, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 12, SupplierName = "Pentel VN Distributor", ContactName = "Vũ Quang F", PhoneNumber = "0902000012", Address = "Q.1, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 13, SupplierName = "NT Cutter Logistics", ContactName = "Hoàng Minh G", PhoneNumber = "0902000013", Address = "Q.10, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 14, SupplierName = "Sunlemon Gifts VN", ContactName = "Trần Thị H", PhoneNumber = "0902000014", Address = "Q. Thủ Đức, TP. HCM", OriginRegion = "Nhật Bản" },
                new Supplier { SupplierId = 15, SupplierName = "Hàng Nhật Nội Địa Sài Gòn", ContactName = "Phan Thị N", PhoneNumber = "0902000015", Address = "Q. Tân Bình, TP. HCM", OriginRegion = "Việt Nam" }
            );

            // 4. Dữ liệu mẫu Khuyến mãi
            modelBuilder.Entity<Promotion>().HasData(
                new Promotion { PromotionId = 1, Code = "DAISO10", Description = "Giảm 10% cho đơn hàng tiện ích từ 300.000 VNĐ", DiscountAmount = 0m, DiscountPercent = 10.0, StartDate = new DateTime(2026, 10, 1), EndDate = new DateTime(2026, 12, 31), IsActive = true },
                new Promotion { PromotionId = 2, Code = "DAISO20K", Description = "Giảm 20.000 VNĐ cho đơn hàng từ 200.000 VNĐ", DiscountAmount = 20000m, DiscountPercent = 0.0, StartDate = new DateTime(2026, 10, 1), EndDate = new DateTime(2026, 12, 31), IsActive = true },
                new Promotion { PromotionId = 3, Code = "KITCHEN15", Description = "Giảm 15% cho dụng cụ nhà bếp thông minh", DiscountAmount = 0m, DiscountPercent = 15.0, StartDate = new DateTime(2026, 10, 1), EndDate = new DateTime(2026, 11, 30), IsActive = true },
                new Promotion { PromotionId = 4, Code = "WELCOME", Description = "Giảm 10% cho khách hàng mới mua lần đầu", DiscountAmount = 0m, DiscountPercent = 10.0, StartDate = new DateTime(2026, 10, 1), EndDate = new DateTime(2027, 12, 31), IsActive = true },
                new Promotion { PromotionId = 5, Code = "FREESHIP", Description = "Miễn phí vận chuyển cho đơn trên 300k", DiscountAmount = 0m, DiscountPercent = 0.0, StartDate = new DateTime(2026, 10, 1), EndDate = new DateTime(2027, 6, 30), IsActive = true },
                new Promotion { PromotionId = 6, Code = "STATIONERY", Description = "Giảm 15% văn phòng phẩm kiểu Nhật", DiscountAmount = 0m, DiscountPercent = 15.0, StartDate = new DateTime(2026, 10, 5), EndDate = new DateTime(2026, 12, 31), IsActive = true },
                new Promotion { PromotionId = 7, Code = "BENTO30", Description = "Giảm 30% khi mua bộ hộp cơm Bento & phụ kiện", DiscountAmount = 0m, DiscountPercent = 30.0, StartDate = new DateTime(2026, 10, 1), EndDate = new DateTime(2026, 12, 31), IsActive = true },
                new Promotion { PromotionId = 8, Code = "MEMBER5", Description = "Thành viên giảm 5% mọi hóa đơn", DiscountAmount = 0m, DiscountPercent = 5.0, StartDate = new DateTime(2026, 10, 1), EndDate = new DateTime(2028, 12, 31), IsActive = true },
                new Promotion { PromotionId = 9, Code = "BEAUTY15", Description = "Giảm 15% cho sản phẩm làm đẹp & chăm sóc cá nhân", DiscountAmount = 0m, DiscountPercent = 15.0, StartDate = new DateTime(2026, 10, 1), EndDate = new DateTime(2027, 5, 31), IsActive = true },
                new Promotion { PromotionId = 10, Code = "GOLDENHOUR", Description = "Khuyến mãi giờ vàng đồng giá siêu tiết kiệm", DiscountAmount = 0m, DiscountPercent = 10.0, StartDate = new DateTime(2026, 10, 20), EndDate = new DateTime(2026, 10, 21), IsActive = true }
            );

            // 5. Dữ liệu mẫu Người dùng hệ thống
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin01", PasswordHash = "123456", FullName = "Nguyễn Quản Trị", Role = "Admin", IsActive = true },
                new User { UserId = 2, Username = "admin02", PasswordHash = "123456", FullName = "Trần Giám Đốc", Role = "Admin", IsActive = true },
                new User { UserId = 3, Username = "cashier01", PasswordHash = "123456", FullName = "Lê Thu Ngân", Role = "Cashier", IsActive = true },
                new User { UserId = 4, Username = "cashier02", PasswordHash = "123456", FullName = "Phạm Bán Hàng", Role = "Cashier", IsActive = true },
                new User { UserId = 5, Username = "cashier03", PasswordHash = "123456", FullName = "Hoàng Thu Ngân", Role = "Cashier", IsActive = true },
                new User { UserId = 6, Username = "cashier04", PasswordHash = "123456", FullName = "Vũ Thị Quầy", Role = "Cashier", IsActive = true },
                new User { UserId = 7, Username = "cashier05", PasswordHash = "123456", FullName = "Đỗ Bán Lẻ", Role = "Cashier", IsActive = true },
                new User { UserId = 8, Username = "ware01", PasswordHash = "123456", FullName = "Ngô Quản Kho", Role = "Warehouse", IsActive = true },
                new User { UserId = 9, Username = "ware02", PasswordHash = "123456", FullName = "Bùi Kiểm Kê", Role = "Warehouse", IsActive = true },
                new User { UserId = 10, Username = "ware03", PasswordHash = "123456", FullName = "Dương Thủ Kho", Role = "Warehouse", IsActive = true },
                new User { UserId = 11, Username = "ware04", PasswordHash = "123456", FullName = "Lý Nhập Hàng", Role = "Warehouse", IsActive = true },
                new User { UserId = 12, Username = "admin_backup", PasswordHash = "123456", FullName = "Đặng Hỗ Trợ", Role = "Admin", IsActive = true },
                new User { UserId = 13, Username = "cashier06", PasswordHash = "123456", FullName = "Hồ Ca Chiều", Role = "Cashier", IsActive = true },
                new User { UserId = 14, Username = "ware05", PasswordHash = "123456", FullName = "Trương Vận Chuyển", Role = "Warehouse", IsActive = true },
                new User { UserId = 15, Username = "supervisor", PasswordHash = "123456", FullName = "Mai Giám Sát", Role = "Admin", IsActive = true }
            );

            // 6. Dữ liệu mẫu Đơn hàng (Cửa hàng tiện ích Daiso Mini)
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, OrderDate = new DateTime(2026, 10, 2, 9, 30, 0), TotalAmount = 120000m, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 1 },
                new Order { OrderId = 2, OrderDate = new DateTime(2026, 10, 3, 11, 15, 0), TotalAmount = 80000m, PaymentStatus = "Paid", PaymentMethod = "Banking", CustomerId = 2 },
                new Order { OrderId = 3, OrderDate = new DateTime(2026, 10, 4, 14, 0, 0), TotalAmount = 160000m, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 3 },
                new Order { OrderId = 4, OrderDate = new DateTime(2026, 10, 5, 16, 20, 0), TotalAmount = 200000m, PaymentStatus = "Paid", PaymentMethod = "QR Code", CustomerId = 4 },
                new Order { OrderId = 5, OrderDate = new DateTime(2026, 10, 6, 10, 5, 0), TotalAmount = 40000m, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 5 },
                new Order { OrderId = 6, OrderDate = new DateTime(2026, 10, 6, 13, 30, 0), TotalAmount = 120000m, PaymentStatus = "Paid", PaymentMethod = "Card", CustomerId = 6 },
                new Order { OrderId = 7, OrderDate = new DateTime(2026, 10, 7, 15, 45, 0), TotalAmount = 80000m, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 7 },
                new Order { OrderId = 8, OrderDate = new DateTime(2026, 10, 8, 9, 10, 0), TotalAmount = 160000m, PaymentStatus = "Paid", PaymentMethod = "Banking", CustomerId = 8 },
                new Order { OrderId = 9, OrderDate = new DateTime(2026, 10, 8, 12, 50, 0), TotalAmount = 40000m, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 9 },
                new Order { OrderId = 10, OrderDate = new DateTime(2026, 10, 9, 17, 0, 0), TotalAmount = 240000m, PaymentStatus = "Paid", PaymentMethod = "Card", CustomerId = 10 },
                new Order { OrderId = 11, OrderDate = new DateTime(2026, 10, 10, 10, 30, 0), TotalAmount = 80000m, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 11 },
                new Order { OrderId = 12, OrderDate = new DateTime(2026, 10, 10, 11, 0, 0), TotalAmount = 200000m, PaymentStatus = "Paid", PaymentMethod = "QR Code", CustomerId = 12 },
                new Order { OrderId = 13, OrderDate = new DateTime(2026, 10, 11, 14, 20, 0), TotalAmount = 120000m, PaymentStatus = "Paid", PaymentMethod = "Cash", CustomerId = 13 },
                new Order { OrderId = 14, OrderDate = new DateTime(2026, 10, 12, 16, 45, 0), TotalAmount = 80000m, PaymentStatus = "Paid", PaymentMethod = "Banking", CustomerId = 14 },
                new Order { OrderId = 15, OrderDate = new DateTime(2026, 10, 13, 9, 5, 0), TotalAmount = 160000m, PaymentStatus = "Paid", PaymentMethod = "Card", CustomerId = 15 }
            );

            // 7. Dữ liệu mẫu Chi tiết đơn hàng
            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail { OrderDetailId = 1, OrderId = 1, ProductId = 1, Quantity = 2, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 2, OrderId = 1, ProductId = 3, Quantity = 1, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 3, OrderId = 2, ProductId = 2, Quantity = 2, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 4, OrderId = 2, ProductId = 6, Quantity = 1, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 5, OrderId = 3, ProductId = 4, Quantity = 4, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 6, OrderId = 4, ProductId = 5, Quantity = 5, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 7, OrderId = 4, ProductId = 7, Quantity = 1, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 8, OrderId = 5, ProductId = 8, Quantity = 1, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 9, OrderId = 6, ProductId = 9, Quantity = 3, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 10, OrderId = 7, ProductId = 10, Quantity = 2, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 11, OrderId = 8, ProductId = 11, Quantity = 4, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 12, OrderId = 8, ProductId = 12, Quantity = 1, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 13, OrderId = 9, ProductId = 13, Quantity = 1, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 14, OrderId = 10, ProductId = 14, Quantity = 6, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 15, OrderId = 11, ProductId = 15, Quantity = 2, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 16, OrderId = 12, ProductId = 1, Quantity = 5, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 17, OrderId = 13, ProductId = 2, Quantity = 3, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 18, OrderId = 14, ProductId = 3, Quantity = 2, UnitPrice = 40000m },
                new OrderDetail { OrderDetailId = 19, OrderId = 15, ProductId = 4, Quantity = 4, UnitPrice = 40000m }
            );

            // 8. Dữ liệu mẫu Nhật ký kho (InventoryLog)
            modelBuilder.Entity<InventoryLog>().HasData(
                new InventoryLog { LogId = 1, ProductId = 1, TransactionType = "IMPORT", QuantityChange = 50, TransactionDate = new DateTime(2026, 10, 1, 8, 0, 0), BatchNumber = "LOT-DAISO-20261001", ExpirationDate = null, Note = "Nhập kho hộp nhựa chịu nhiệt", SupplierId = 1 },
                new InventoryLog { LogId = 2, ProductId = 2, TransactionType = "IMPORT", QuantityChange = 60, TransactionDate = new DateTime(2026, 10, 2, 9, 0, 0), BatchNumber = "LOT-DAISO-20261002", ExpirationDate = null, Note = "Nhập băng dính Washi Tape", SupplierId = 2 },
                new InventoryLog { LogId = 3, ProductId = 3, TransactionType = "IMPORT", QuantityChange = 40, TransactionDate = new DateTime(2026, 10, 2, 10, 0, 0), BatchNumber = "LOT-DAISO-20261003", ExpirationDate = null, Note = "Nhập khăn lau Microfiber", SupplierId = 3 },
                new InventoryLog { LogId = 4, ProductId = 4, TransactionType = "IMPORT", QuantityChange = 50, TransactionDate = new DateTime(2026, 10, 3, 11, 0, 0), BatchNumber = "LOT-DAISO-20261004", ExpirationDate = null, Note = "Nhập bộ muỗng nĩa inox", SupplierId = 4 },
                new InventoryLog { LogId = 5, ProductId = 5, TransactionType = "IMPORT", QuantityChange = 35, TransactionDate = new DateTime(2026, 10, 3, 12, 0, 0), BatchNumber = "LOT-DAISO-20261005", ExpirationDate = null, Note = "Nhập bình giữ nhiệt mini", SupplierId = 5 },
                new InventoryLog { LogId = 6, ProductId = 6, TransactionType = "IMPORT", QuantityChange = 45, TransactionDate = new DateTime(2026, 10, 4, 8, 30, 0), BatchNumber = "LOT-DAISO-20261006", ExpirationDate = null, Note = "Nhập sổ tay kẻ ngang", SupplierId = 6 },
                new InventoryLog { LogId = 7, ProductId = 7, TransactionType = "IMPORT", QuantityChange = 30, TransactionDate = new DateTime(2026, 10, 4, 9, 30, 0), BatchNumber = "LOT-DAISO-20261007", ExpirationDate = new DateTime(2028, 1, 1), Note = "Nhập bông tẩy trang", SupplierId = 7 },
                new InventoryLog { LogId = 8, ProductId = 8, TransactionType = "IMPORT", QuantityChange = 25, TransactionDate = new DateTime(2026, 10, 5, 10, 0, 0), BatchNumber = "LOT-DAISO-20261008", ExpirationDate = null, Note = "Nhập dao gọt trái cây", SupplierId = 8 },
                new InventoryLog { LogId = 9, ProductId = 9, TransactionType = "IMPORT", QuantityChange = 50, TransactionDate = new DateTime(2026, 10, 5, 11, 0, 0), BatchNumber = "LOT-DAISO-20261009", ExpirationDate = null, Note = "Nhập hộp cơm Bento", SupplierId = 9 },
                new InventoryLog { LogId = 10, ProductId = 10, TransactionType = "IMPORT", QuantityChange = 40, TransactionDate = new DateTime(2026, 10, 6, 8, 0, 0), BatchNumber = "LOT-DAISO-20261010", ExpirationDate = null, Note = "Nhập màng bọc thực phẩm", SupplierId = 10 },
                new InventoryLog { LogId = 11, ProductId = 11, TransactionType = "IMPORT", QuantityChange = 30, TransactionDate = new DateTime(2026, 10, 6, 9, 0, 0), BatchNumber = "LOT-DAISO-20261011", ExpirationDate = null, Note = "Nhập rổ nhựa đa năng", SupplierId = 11 },
                new InventoryLog { LogId = 12, ProductId = 12, TransactionType = "IMPORT", QuantityChange = 25, TransactionDate = new DateTime(2026, 10, 7, 10, 0, 0), BatchNumber = "LOT-DAISO-20261012", ExpirationDate = null, Note = "Nhập bút bi mực gel", SupplierId = 12 },
                new InventoryLog { LogId = 13, ProductId = 13, TransactionType = "IMPORT", QuantityChange = 40, TransactionDate = new DateTime(2026, 10, 7, 11, 0, 0), BatchNumber = "LOT-DAISO-20261013", ExpirationDate = null, Note = "Nhập kéo văn phòng", SupplierId = 13 },
                new InventoryLog { LogId = 14, ProductId = 14, TransactionType = "IMPORT", QuantityChange = 30, TransactionDate = new DateTime(2026, 10, 8, 12, 0, 0), BatchNumber = "LOT-DAISO-20261014", ExpirationDate = null, Note = "Nhập thú bông móc khóa", SupplierId = 14 },
                new InventoryLog { LogId = 15, ProductId = 15, TransactionType = "IMPORT", QuantityChange = 20, TransactionDate = new DateTime(2026, 10, 8, 13, 0, 0), BatchNumber = "LOT-DAISO-20261015", ExpirationDate = null, Note = "Nhập nước rửa chén sinh học", SupplierId = 15 }
            );

            // Cấu hình quan hệ bảng
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}