using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class InitDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrandName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OriginRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    RewardPoints = table.Column<int>(type: "int", nullable: false),
                    MembershipRank = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Promotions",
                columns: table => new
                {
                    PromotionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    DiscountAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DiscountPercent = table.Column<double>(type: "float", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promotions", x => x.PromotionId);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ContactName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    OriginRegion = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "BrandId");
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    PaymentMethod = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CustomerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId");
                });

            migrationBuilder.CreateTable(
                name: "InventoryLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    TransactionType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    QuantityChange = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BatchNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SupplierId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_InventoryLogs_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InventoryLogs_Suppliers_SupplierId",
                        column: x => x.SupplierId,
                        principalTable: "Suppliers",
                        principalColumn: "SupplierId");
                });

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "BrandName", "Description", "OriginRegion" },
                values: new object[,]
                {
                    { 1, "Daiso Original", "Sản phẩm tiện ích độc quyền Daiso", "Nhật Bản" },
                    { 2, "Sanada", "Đồ nhựa gia dụng cao cấp Nhật Bản", "Nhật Bản" },
                    { 3, "Inomata", "Đồ dùng nhà bếp thông minh", "Nhật Bản" },
                    { 4, "Kowa", "Dụng cụ vệ sinh & chăm sóc nhà cửa", "Nhật Bản" },
                    { 5, "Kokuyo", "Văn phòng phẩm chất lượng cao", "Nhật Bản" },
                    { 6, "Pentel", "Bút viết và họa phẩm", "Nhật Bản" },
                    { 7, "NT Cutter", "Dao rọc giấy và dụng cụ cắt", "Nhật Bản" },
                    { 8, "Ebisu", "Chăm sóc cá nhân & bàn chải đánh răng", "Nhật Bản" },
                    { 9, "Lion", "Hóa mỹ phẩm & tẩy rửa", "Nhật Bản" },
                    { 10, "Sunlemon", "Thú bông & quà tặng dễ thương", "Nhật Bản" },
                    { 11, "Kai", "Dụng cụ nhà bếp & làm móng", "Nhật Bản" },
                    { 12, "Seria Style", "Phụ kiện trang trí phong cách Nhật", "Nhật Bản" },
                    { 13, "Yamada", "Hộp đựng và tổ chức không gian", "Nhật Bản" },
                    { 14, "Asvel", "Bình nước & hộp đựng thực phẩm", "Nhật Bản" },
                    { 15, "Skater", "Đồ dùng bento & hộp cơm", "Nhật Bản" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "Đồ dùng nhà bếp", "Dụng cụ nấu ăn, hộp đựng thực phẩm", true },
                    { 2, "Văn phòng phẩm", "Bút, sổ tay, dụng cụ học tập", true },
                    { 3, "Vệ sinh nhà cửa", "Dụng cụ dọn dẹp, chất tẩy rửa", true },
                    { 4, "Chăm sóc cá nhân", "Làm đẹp, mỹ phẩm, sức khỏe", true },
                    { 5, "Đồ gia dụng & Lưu trữ", "Hộp đựng, rổ nhựa, đồ dùng phòng khách", true },
                    { 6, "Quà tặng & Phụ kiện", "Thú bông, móc khóa, đồ trang trí", true }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "CustomerName", "MembershipRank", "PhoneNumber", "RewardPoints" },
                values: new object[,]
                {
                    { 1, "Quận 1, TP. HCM", "Nguyễn Văn An", "Gold", "0901111111", 120 },
                    { 2, "Quận 3, TP. HCM", "Trần Thị Bình", "Silver", "0902222222", 50 },
                    { 3, "Quận 5, TP. HCM", "Lê Hoàng Cường", "Platinum", "0903333333", 200 },
                    { 4, "Quận 7, TP. HCM", "Phạm Thị Dung", "Bronze", "0904444444", 10 },
                    { 5, "Quận 10, TP. HCM", "Hoàng Văn Em", "Silver", "0905555555", 80 },
                    { 6, "Quận Gò Vấp, TP. HCM", "Vũ Thị Phương", "Gold", "0906666666", 150 },
                    { 7, "Quận Tân Bình, TP. HCM", "Đỗ Minh Giang", "Bronze", "0907777777", 30 },
                    { 8, "Quận Bình Thạnh, TP. HCM", "Bùi Thanh Hằng", "Silver", "0908888888", 90 },
                    { 9, "TP. Thủ Đức, TP. HCM", "Ngô Văn Hùng", "Platinum", "0909999999", 220 },
                    { 10, "Quận 4, TP. HCM", "Dương Thị Kim", "Bronze", "0901010101", 40 },
                    { 11, "Quận 11, TP. HCM", "Lý Văn Long", "Gold", "0901212121", 110 },
                    { 12, "Quận 12, TP. HCM", "Đặng Thị Mai", "Silver", "0901313131", 60 },
                    { 13, "Hóc Môn, TP. HCM", "Hồ Văn Nam", "Gold", "0901414141", 180 },
                    { 14, "Củ Chi, TP. HCM", "Trương Thị Oanh", "Bronze", "0901515151", 20 },
                    { 15, "Bình Chánh, TP. HCM", "Phan Văn Phúc", "Gold", "0901616161", 130 }
                });

            migrationBuilder.InsertData(
                table: "Promotions",
                columns: new[] { "PromotionId", "Code", "Description", "DiscountAmount", "DiscountPercent", "EndDate", "IsActive", "StartDate" },
                values: new object[,]
                {
                    { 1, "DAISO10", "Giảm 10% cho đơn hàng tiện ích từ 300.000 VNĐ", 0m, 10.0, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "DAISO20K", "Giảm 20.000 VNĐ cho đơn hàng từ 200.000 VNĐ", 20000m, 0.0, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "KITCHEN15", "Giảm 15% cho dụng cụ nhà bếp thông minh", 0m, 15.0, new DateTime(2026, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "WELCOME", "Giảm 10% cho khách hàng mới mua lần đầu", 0m, 10.0, new DateTime(2027, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "FREESHIP", "Miễn phí vận chuyển cho đơn trên 300k", 0m, 0.0, new DateTime(2027, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "STATIONERY", "Giảm 15% văn phòng phẩm kiểu Nhật", 0m, 15.0, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "BENTO30", "Giảm 30% khi mua bộ hộp cơm Bento & phụ kiện", 0m, 30.0, new DateTime(2026, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "MEMBER5", "Thành viên giảm 5% mọi hóa đơn", 0m, 5.0, new DateTime(2028, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "BEAUTY15", "Giảm 15% cho sản phẩm làm đẹp & chăm sóc cá nhân", 0m, 15.0, new DateTime(2027, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "GOLDENHOUR", "Khuyến mãi giờ vàng đồng giá siêu tiết kiệm", 0m, 10.0, new DateTime(2026, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2026, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Suppliers",
                columns: new[] { "SupplierId", "Address", "ContactName", "OriginRegion", "PhoneNumber", "SupplierName" },
                values: new object[,]
                {
                    { 1, "KCN Tân Bình, TP. HCM", "Nguyễn Hoàng Nam", "Nhật Bản", "0902000001", "Công ty TNHH Nhập khẩu Daiso Việt Nam" },
                    { 2, "Q. Bình Thạnh, TP. HCM", "Trần Minh Hà", "Nhật Bản", "0902000002", "Nhà phân phối Sanada Japan" },
                    { 3, "Q.12, TP. HCM", "Lê Quốc Thắng", "Nhật Bản", "0902000003", "Công ty TNHH Inomata VN" },
                    { 4, "Q.7, TP. HCM", "Phạm Ngọc Lan", "Nhật Bản", "0902000004", "Kokuyo Vietnam Trading" },
                    { 5, "Bình Dương", "Vũ Thanh Sơn", "Nhật Bản", "0902000005", "Công ty Thương mại Kai Japan" },
                    { 6, "Q.1, TP. HCM", "Ngô Văn A", "Nhật Bản", "0902000006", "Tokyo Lifestyle Supply" },
                    { 7, "Q.3, TP. HCM", "Lê Thị B", "Nhật Bản", "0902000007", "Lion Corporation VN" },
                    { 8, "Hải Phòng", "André Rossi", "Nhật Bản", "0902000008", "Asvel Vietnam Import" },
                    { 9, "Bình Dương", "Trương Văn C", "Nhật Bản", "0902000009", "Skater Bento House" },
                    { 10, "Gò Vấp, TP. HCM", "Đỗ Thị D", "Nhật Bản", "0902000010", "Yamada Household Goods" },
                    { 11, "Q.5, TP. HCM", "Trương Văn E", "Nhật Bản", "0902000011", "Global Japan Trade" },
                    { 12, "Q.1, TP. HCM", "Vũ Quang F", "Nhật Bản", "0902000012", "Pentel VN Distributor" },
                    { 13, "Q.10, TP. HCM", "Hoàng Minh G", "Nhật Bản", "0902000013", "NT Cutter Logistics" },
                    { 14, "Q. Thủ Đức, TP. HCM", "Trần Thị H", "Nhật Bản", "0902000014", "Sunlemon Gifts VN" },
                    { 15, "Q. Tân Bình, TP. HCM", "Phan Thị N", "Việt Nam", "0902000015", "Hàng Nhật Nội Địa Sài Gòn" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FullName", "IsActive", "PasswordHash", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Nguyễn Quản Trị", true, "123456", "Admin", "admin01" },
                    { 2, "Trần Giám Đốc", true, "123456", "Admin", "admin02" },
                    { 3, "Lê Thu Ngân", true, "123456", "Cashier", "cashier01" },
                    { 4, "Phạm Bán Hàng", true, "123456", "Cashier", "cashier02" },
                    { 5, "Hoàng Thu Ngân", true, "123456", "Cashier", "cashier03" },
                    { 6, "Vũ Thị Quầy", true, "123456", "Cashier", "cashier04" },
                    { 7, "Đỗ Bán Lẻ", true, "123456", "Cashier", "cashier05" },
                    { 8, "Ngô Quản Kho", true, "123456", "Warehouse", "ware01" },
                    { 9, "Bùi Kiểm Kê", true, "123456", "Warehouse", "ware02" },
                    { 10, "Dương Thủ Kho", true, "123456", "Warehouse", "ware03" },
                    { 11, "Lý Nhập Hàng", true, "123456", "Warehouse", "ware04" },
                    { 12, "Đặng Hỗ Trợ", true, "123456", "Admin", "admin_backup" },
                    { 13, "Hồ Ca Chiều", true, "123456", "Cashier", "cashier06" },
                    { 14, "Trương Vận Chuyển", true, "123456", "Warehouse", "ware05" },
                    { 15, "Mai Giám Sát", true, "123456", "Admin", "supervisor" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderId", "CustomerId", "OrderDate", "PaymentMethod", "PaymentStatus", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 10, 2, 9, 30, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 120000m },
                    { 2, 2, new DateTime(2026, 10, 3, 11, 15, 0, 0, DateTimeKind.Unspecified), "Banking", "Paid", 80000m },
                    { 3, 3, new DateTime(2026, 10, 4, 14, 0, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 160000m },
                    { 4, 4, new DateTime(2026, 10, 5, 16, 20, 0, 0, DateTimeKind.Unspecified), "QR Code", "Paid", 200000m },
                    { 5, 5, new DateTime(2026, 10, 6, 10, 5, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 40000m },
                    { 6, 6, new DateTime(2026, 10, 6, 13, 30, 0, 0, DateTimeKind.Unspecified), "Card", "Paid", 120000m },
                    { 7, 7, new DateTime(2026, 10, 7, 15, 45, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 80000m },
                    { 8, 8, new DateTime(2026, 10, 8, 9, 10, 0, 0, DateTimeKind.Unspecified), "Banking", "Paid", 160000m },
                    { 9, 9, new DateTime(2026, 10, 8, 12, 50, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 40000m },
                    { 10, 10, new DateTime(2026, 10, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), "Card", "Paid", 240000m },
                    { 11, 11, new DateTime(2026, 10, 10, 10, 30, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 80000m },
                    { 12, 12, new DateTime(2026, 10, 10, 11, 0, 0, 0, DateTimeKind.Unspecified), "QR Code", "Paid", 200000m },
                    { 13, 13, new DateTime(2026, 10, 11, 14, 20, 0, 0, DateTimeKind.Unspecified), "Cash", "Paid", 120000m },
                    { 14, 14, new DateTime(2026, 10, 12, 16, 45, 0, 0, DateTimeKind.Unspecified), "Banking", "Paid", 80000m },
                    { 15, 15, new DateTime(2026, 10, 13, 9, 5, 0, 0, DateTimeKind.Unspecified), "Card", "Paid", 160000m }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "BrandId", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "8930000000001", null, 5, 40000m, "Hộp nhựa chịu nhiệt", 50 },
                    { 2, "8930000000002", null, 2, 40000m, "Băng dính Washi Tape", 60 },
                    { 3, "8930000000003", null, 3, 40000m, "Khăn lau Microfiber", 40 },
                    { 4, "8930000000004", null, 1, 40000m, "Bộ muỗng nĩa inox", 50 },
                    { 5, "8930000000005", null, 5, 40000m, "Bình giữ nhiệt mini", 35 },
                    { 6, "8930000000006", null, 2, 40000m, "Sổ tay kẻ ngang", 45 },
                    { 7, "8930000000007", null, 4, 40000m, "Bông tẩy trang", 30 },
                    { 8, "8930000000008", null, 1, 40000m, "Dao gọt trái cây", 25 },
                    { 9, "8930000000009", null, 1, 40000m, "Hộp cơm Bento", 50 },
                    { 10, "8930000000010", null, 1, 40000m, "Màng bọc thực phẩm", 40 },
                    { 11, "8930000000011", null, 5, 40000m, "Rổ nhựa đa năng", 30 },
                    { 12, "8930000000012", null, 2, 40000m, "Bút bi mực gel", 25 },
                    { 13, "8930000000013", null, 2, 40000m, "Kéo văn phòng", 40 },
                    { 14, "8930000000014", null, 6, 40000m, "Thú bông móc khóa", 30 },
                    { 15, "8930000000015", null, 3, 40000m, "Nước rửa chén sinh học", 20 }
                });

            migrationBuilder.InsertData(
                table: "InventoryLogs",
                columns: new[] { "LogId", "BatchNumber", "ExpirationDate", "Note", "ProductId", "QuantityChange", "SupplierId", "TransactionDate", "TransactionType" },
                values: new object[,]
                {
                    { 1, "LOT-DAISO-20261001", null, "Nhập kho hộp nhựa chịu nhiệt", 1, 50, 1, new DateTime(2026, 10, 1, 8, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 2, "LOT-DAISO-20261002", null, "Nhập băng dính Washi Tape", 2, 60, 2, new DateTime(2026, 10, 2, 9, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 3, "LOT-DAISO-20261003", null, "Nhập khăn lau Microfiber", 3, 40, 3, new DateTime(2026, 10, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 4, "LOT-DAISO-20261004", null, "Nhập bộ muỗng nĩa inox", 4, 50, 4, new DateTime(2026, 10, 3, 11, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 5, "LOT-DAISO-20261005", null, "Nhập bình giữ nhiệt mini", 5, 35, 5, new DateTime(2026, 10, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 6, "LOT-DAISO-20261006", null, "Nhập sổ tay kẻ ngang", 6, 45, 6, new DateTime(2026, 10, 4, 8, 30, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 7, "LOT-DAISO-20261007", new DateTime(2028, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nhập bông tẩy trang", 7, 30, 7, new DateTime(2026, 10, 4, 9, 30, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 8, "LOT-DAISO-20261008", null, "Nhập dao gọt trái cây", 8, 25, 8, new DateTime(2026, 10, 5, 10, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 9, "LOT-DAISO-20261009", null, "Nhập hộp cơm Bento", 9, 50, 9, new DateTime(2026, 10, 5, 11, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 10, "LOT-DAISO-20261010", null, "Nhập màng bọc thực phẩm", 10, 40, 10, new DateTime(2026, 10, 6, 8, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 11, "LOT-DAISO-20261011", null, "Nhập rổ nhựa đa năng", 11, 30, 11, new DateTime(2026, 10, 6, 9, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 12, "LOT-DAISO-20261012", null, "Nhập bút bi mực gel", 12, 25, 12, new DateTime(2026, 10, 7, 10, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 13, "LOT-DAISO-20261013", null, "Nhập kéo văn phòng", 13, 40, 13, new DateTime(2026, 10, 7, 11, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 14, "LOT-DAISO-20261014", null, "Nhập thú bông móc khóa", 14, 30, 14, new DateTime(2026, 10, 8, 12, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" },
                    { 15, "LOT-DAISO-20261015", null, "Nhập nước rửa chén sinh học", 15, 20, 15, new DateTime(2026, 10, 8, 13, 0, 0, 0, DateTimeKind.Unspecified), "IMPORT" }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "OrderDetailId", "OrderId", "ProductId", "Quantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, 40000m },
                    { 2, 1, 3, 1, 40000m },
                    { 3, 2, 2, 2, 40000m },
                    { 4, 2, 6, 1, 40000m },
                    { 5, 3, 4, 4, 40000m },
                    { 6, 4, 5, 5, 40000m },
                    { 7, 4, 7, 1, 40000m },
                    { 8, 5, 8, 1, 40000m },
                    { 9, 6, 9, 3, 40000m },
                    { 10, 7, 10, 2, 40000m },
                    { 11, 8, 11, 4, 40000m },
                    { 12, 8, 12, 1, 40000m },
                    { 13, 9, 13, 1, 40000m },
                    { 14, 10, 14, 6, 40000m },
                    { 15, 11, 15, 2, 40000m },
                    { 16, 12, 1, 5, 40000m },
                    { 17, 13, 2, 3, 40000m },
                    { 18, 14, 3, 2, 40000m },
                    { 19, 15, 4, 4, 40000m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_ProductId",
                table: "InventoryLogs",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryLogs_SupplierId",
                table: "InventoryLogs",
                column: "SupplierId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BrandId",
                table: "Products",
                column: "BrandId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryLogs");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Promotions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
