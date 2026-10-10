using Microsoft.EntityFrameworkCore;
using MiniSupermarket.API.model;
using MiniSupermarket.API.Models;

namespace MiniSupermarket.API.Data
{
    public class SupermarketDbContext : DbContext
    {
        public SupermarketDbContext(DbContextOptions<SupermarketDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 1. 15 Danh mục sản phẩm Daiso
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Đồ gia dụng tiện ích", Description = "Hộp đựng, móc dán, dụng cụ nhà bếp thông minh" },
                new Category { CategoryId = 2, CategoryName = "Văn phòng phẩm & Quà lưu niệm", Description = "Bút, sổ tay thiết kế Nhật, giấy note" },
                new Category { CategoryId = 3, CategoryName = "Mỹ phẩm & Chăm sóc cá nhân", Description = "Mặt nạ dưỡng da, bông tẩy trang, sữa rửa mặt" },
                new Category { CategoryId = 4, CategoryName = "Đồ ăn vặt & Bánh kẹo Nhật", Description = "Kẹo dẻo UHA, bánh quy Matcha, snack" },
                new Category { CategoryId = 5, CategoryName = "Đồ chơi & Phụ kiện", Description = "Móc khóa anime, đồ chơi lắp ráp mini" },
                new Category { CategoryId = 6, CategoryName = "Đồ dùng nhà bếp & Nấu ăn", Description = "Khuôn làm bánh, dao kéo, thớt nhựa kháng khuẩn" },
                new Category { CategoryId = 7, CategoryName = "Chăm sóc nhà cửa & Giặt ủi", Description = "Túi giặt quần áo, nước thơm phòng, găng tay" },
                new Category { CategoryId = 8, CategoryName = "Phụ kiện thời trang & Làm đẹp", Description = "Kẹp tóc, gương trang điểm, tất vớ Nhật Bản" },
                new Category { CategoryId = 9, CategoryName = "Đồ dùng thú cưng", Description = "Đồ chơi cho mèo, bát ăn, lược chải lông" },
                new Category { CategoryId = 10, CategoryName = "Sản phẩm mùa hè & Tiện ích ngoài trời", Description = "Quạt mini cầm tay, bình giữ nhiệt, túi giữ lạnh" },
                new Category { CategoryId = 11, CategoryName = "Thiết bị điện tử nhỏ & Cáp sạc", Description = "Cáp sạc điện thoại, giá đỡ điện thoại bàn" },
                new Category { CategoryId = 12, CategoryName = "Thực phẩm đóng hộp & Đồ uống", Description = "Trà xanh đóng chai, mỳ ly, cà phê hòa tan" },
                new Category { CategoryId = 13, CategoryName = "Sản phẩm chăm sóc trẻ em", Description = "Yếm ăn dặm, hộp chia sữa, đồ chơi nhà tắm" },
                new Category { CategoryId = 14, CategoryName = "Dụng cụ thể thao & Dã ngoại", Description = "Thảm tập yoga mini, băng đô thể thao, túi rút" },
                new Category { CategoryId = 15, CategoryName = "Hàng trang trí & Đồ theo mùa", Description = "Đèn LED trang trí phòng, thiệp chúc mừng, sticker" }
            );

            // 2. 15 Sản phẩm mẫu kèm mã vạch chuẩn quản lý kho
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, Barcode = "4901234567801", ProductName = "Hộp đựng đồ đa năng Daiso", Price = 45000, StockQuantity = 120, CategoryId = 1 },
                new Product { ProductId = 2, Barcode = "4901234567802", ProductName = "Sổ tay lò xo B5 Nhật Bản", Price = 25000, StockQuantity = 200, CategoryId = 2 },
                new Product { ProductId = 3, Barcode = "4901234567803", ProductName = "Mặt nạ giấy dưỡng ẩm Hyaluronic", Price = 22000, StockQuantity = 300, CategoryId = 3 },
                new Product { ProductId = 4, Barcode = "4901234567804", ProductName = "Kẹo dẻo vị nho xanh UHA", Price = 32000, StockQuantity = 150, CategoryId = 4 },
                new Product { ProductId = 5, Barcode = "4901234567805", ProductName = "Móc khóa mô hình hoạt hình anime", Price = 50000, StockQuantity = 90, CategoryId = 5 },
                new Product { ProductId = 6, Barcode = "4901234567806", ProductName = "Thớt nhựa kháng khuẩn kháng mùi", Price = 65000, StockQuantity = 80, CategoryId = 6 },
                new Product { ProductId = 7, Barcode = "4901234567807", ProductName = "Túi lưới giặt đồ lót máy giặt", Price = 30000, StockQuantity = 140, CategoryId = 7 },
                new Product { ProductId = 8, Barcode = "4901234567808", ProductName = "Gương trang điểm gấp gọn bỏ túi", Price = 40000, StockQuantity = 110, CategoryId = 8 },
                new Product { ProductId = 9, Barcode = "4901234567809", ProductName = "Bát ăn hình mèo ngộ nghĩnh", Price = 55000, StockQuantity = 70, CategoryId = 9 },
                new Product { ProductId = 10, Barcode = "4901234567810", ProductName = "Quạt nhựa mini cầm tay chạy pin", Price = 85000, StockQuantity = 60, CategoryId = 10 },
                new Product { ProductId = 11, Barcode = "4901234567811", ProductName = "Giá đỡ điện thoại để bàn bằng gỗ", Price = 45000, StockQuantity = 130, CategoryId = 11 },
                new Product { ProductId = 12, Barcode = "4901234567812", ProductName = "Trà xanh không đường Oi Ocha", Price = 28000, StockQuantity = 220, CategoryId = 12 },
                new Product { ProductId = 13, Barcode = "4901234567813", ProductName = "Hộp chia sữa bột 3 tầng cho bé", Price = 60000, StockQuantity = 50, CategoryId = 13 },
                new Product { ProductId = 14, Barcode = "4901234567814", ProductName = "Túi rút đựng giày thể thao du lịch", Price = 50000, StockQuantity = 95, CategoryId = 14 },
                new Product { ProductId = 15, Barcode = "4901234567815", ProductName = "Dây đèn LED đom đóm trang trí phòng", Price = 75000, StockQuantity = 100, CategoryId = 15 }
            );

            // 3. 15 Khách hàng thành viên tích điểm
            // 3. Danh sách 15 Khách hàng thành viên tích điểm (Địa chỉ chi tiết)
            modelBuilder.Entity<Customer>().HasData(
                new Customer { CustomerId = 1, FullName = "Nguyễn Văn An", Phone = "0901234501", Address = "123 Đường Lê Lợi, Phường Bến Thành, Quận 1, TP.HCM", LoyaltyPoints = 50 },
                new Customer { CustomerId = 2, FullName = "Trần Thị Mai", Phone = "0901234502", Address = "45 Đường Nam Kỳ Khởi Nghĩa, Phường Võ Thị Sáu, Quận 3, TP.HCM", LoyaltyPoints = 120 },
                new Customer { CustomerId = 3, FullName = "Lê Hoàng Long", Phone = "0901234503", Address = "78 Đường Trần Hưng Đạo, Phường 2, Quận 5, TP.HCM", LoyaltyPoints = 80 },
                new Customer { CustomerId = 4, FullName = "Phạm Thị Hương", Phone = "0901234504", Address = "12 Đường Nguyễn Thị Thập, Phường Tân Phú, Quận 7, TP.HCM", LoyaltyPoints = 200 },
                new Customer { CustomerId = 5, FullName = "Hoàng Minh Tuấn", Phone = "0901234505", Address = "90 Đường Thành Thái, Phường 14, Quận 10, TP.HCM", LoyaltyPoints = 15 },
                new Customer { CustomerId = 6, FullName = "Vũ Thu Trang", Phone = "0901234506", Address = "156 Đường Võ Văn Ngân, Phường Linh Chiểu, Thành phố Thủ Đức, TP.HCM", LoyaltyPoints = 310 },
                new Customer { CustomerId = 7, FullName = "Đặng Quốc Việt", Phone = "0901234507", Address = "234 Đường Bạch Đằng, Phường 24, Quận Bình Thạnh, TP.HCM", LoyaltyPoints = 90 },
                new Customer { CustomerId = 8, FullName = "Bùi Thị Lan", Phone = "0901234508", Address = "56 Đường Phan Xích Long, Phường 2, Quận Phú Nhuận, TP.HCM", LoyaltyPoints = 45 },
                new Customer { CustomerId = 9, FullName = "Ngô Văn Hùng", Phone = "0901234509", Address = "89 Đường Cộng Hòa, Phường 4, Quận Tân Bình, TP.HCM", LoyaltyPoints = 175 },
                new Customer { CustomerId = 10, FullName = "Dương Mỹ Linh", Phone = "0901234510", Address = "345 Đường Nguyễn Oanh, Phường 17, Quận Gò Vấp, TP.HCM", LoyaltyPoints = 230 },
                new Customer { CustomerId = 11, FullName = "Lý Hải Nam", Phone = "0901234511", Address = "67 Đường Tôn Đản, Phường 8, Quận 4, TP.HCM", LoyaltyPoints = 60 },
                new Customer { CustomerId = 12, FullName = "Đỗ Quỳnh Nga", Phone = "0901234512", Address = "120 Đường Phạm Hùng, Phường 4, Quận 8, TP.HCM", LoyaltyPoints = 110 },
                new Customer { CustomerId = 13, FullName = "Hồ Tấn Phát", Phone = "0901234513", Address = "34 Đường Lạc Long Quân, Phường 3, Quận 11, TP.HCM", LoyaltyPoints = 140 },
                new Customer { CustomerId = 14, FullName = "Cao Thị Yến", Phone = "0901234514", Address = "210 Đường Trương Phước Phan, Phường Bình Trị Đông, Quận Tân Phú, TP.HCM", LoyaltyPoints = 25 },
                new Customer { CustomerId = 15, FullName = "Trịnh Công Sơn", Phone = "0901234515", Address = "567 Đường Quốc Lộ 1A, Phường Bình Hưng Hòa B, Quận Bình Tân, TP.HCM", LoyaltyPoints = 300 }
            );

            // 4. Tài khoản quản lý và nhân viên
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, Username = "admin", Password = "123456", FullName = "Quản lý cửa hàng Daiso", Role = "Admin" },
                new User { UserId = 2, Username = "cashier1", Password = "123456", FullName = "Thu ngân ca sáng", Role = "Staff" }
            );
        }
    }
}