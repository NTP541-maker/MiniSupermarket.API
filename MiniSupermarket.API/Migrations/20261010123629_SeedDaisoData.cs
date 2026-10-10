using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedDaisoData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LoyaltyPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Đồ gia dụng tiện ích", "Hộp đựng, móc dán, dụng cụ nhà bếp thông minh" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Văn phòng phẩm & Quà lưu niệm", "Bút, sổ tay thiết kế Nhật, giấy note" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Mỹ phẩm & Chăm sóc cá nhân", "Mặt nạ dưỡng da, bông tẩy trang, sữa rửa mặt" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Đồ ăn vặt & Bánh kẹo Nhật", "Kẹo dẻo UHA, bánh quy Matcha, snack" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Đồ chơi & Phụ kiện", "Móc khóa anime, đồ chơi lắp ráp mini" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName", "Description" },
                values: new object[,]
                {
                    { 6, "Đồ dùng nhà bếp & Nấu ăn", "Khuôn làm bánh, dao kéo, thớt nhựa kháng khuẩn" },
                    { 7, "Chăm sóc nhà cửa & Giặt ủi", "Túi giặt quần áo, nước thơm phòng, găng tay" },
                    { 8, "Phụ kiện thời trang & Làm đẹp", "Kẹp tóc, gương trang điểm, tất vớ Nhật Bản" },
                    { 9, "Đồ dùng thú cưng", "Đồ chơi cho mèo, bát ăn, lược chải lông" },
                    { 10, "Sản phẩm mùa hè & Tiện ích ngoài trời", "Quạt mini cầm tay, bình giữ nhiệt, túi giữ lạnh" },
                    { 11, "Thiết bị điện tử nhỏ & Cáp sạc", "Cáp sạc điện thoại, giá đỡ điện thoại bàn" },
                    { 12, "Thực phẩm đóng hộp & Đồ uống", "Trà xanh đóng chai, mỳ ly, cà phê hòa tan" },
                    { 13, "Sản phẩm chăm sóc trẻ em", "Yếm ăn dặm, hộp chia sữa, đồ chơi nhà tắm" },
                    { 14, "Dụng cụ thể thao & Dã ngoại", "Thảm tập yoga mini, băng đô thể thao, túi rút" },
                    { 15, "Hàng trang trí & Đồ theo mùa", "Đèn LED trang trí phòng, thiệp chúc mừng, sticker" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Address", "FullName", "LoyaltyPoints", "Phone" },
                values: new object[,]
                {
                    { 1, "Quận 1, TP.HCM", "Nguyễn Văn An", 50, "0901234501" },
                    { 2, "Quận 3, TP.HCM", "Trần Thị Mai", 120, "0901234502" },
                    { 3, "Quận 5, TP.HCM", "Lê Hoàng Long", 80, "0901234503" },
                    { 4, "Quận 7, TP.HCM", "Phạm Thị Hương", 200, "0901234504" },
                    { 5, "Quận 10, TP.HCM", "Hoàng Minh Tuấn", 15, "0901234505" },
                    { 6, "Thủ Đức, TP.HCM", "Vũ Thu Trang", 310, "0901234506" },
                    { 7, "Bình Thạnh, TP.HCM", "Đặng Quốc Việt", 90, "0901234507" },
                    { 8, "Phú Nhuận, TP.HCM", "Bùi Thị Lan", 45, "0901234508" },
                    { 9, "Tân Bình, TP.HCM", "Ngô Văn Hùng", 175, "0901234509" },
                    { 10, "Gò Vấp, TP.HCM", "Dương Mỹ Linh", 230, "0901234510" },
                    { 11, "Quận 4, TP.HCM", "Lý Hải Nam", 60, "0901234511" },
                    { 12, "Quận 8, TP.HCM", "Đỗ Quỳnh Nga", 110, "0901234512" },
                    { 13, "Quận 11, TP.HCM", "Hồ Tấn Phát", 140, "0901234513" },
                    { 14, "Tân Phú, TP.HCM", "Cao Thị Yến", 25, "0901234514" },
                    { 15, "Bình Tân, TP.HCM", "Trịnh Công Sơn", 300, "0901234515" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 1, "4901234567801", 1, 45000m, "Hộp đựng đồ đa năng Daiso", 120 },
                    { 2, "4901234567802", 2, 25000m, "Sổ tay lò xo B5 Nhật Bản", 200 },
                    { 3, "4901234567803", 3, 22000m, "Mặt nạ giấy dưỡng ẩm Hyaluronic", 300 },
                    { 4, "4901234567804", 4, 32000m, "Kẹo dẻo vị nho xanh UHA", 150 },
                    { 5, "4901234567805", 5, 50000m, "Móc khóa mô hình hoạt hình anime", 90 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "FullName", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "Quản lý cửa hàng Daiso", "123456", "Admin", "admin" },
                    { 2, "Thu ngân ca sáng", "123456", "Staff", "cashier1" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Barcode", "CategoryId", "Price", "ProductName", "StockQuantity" },
                values: new object[,]
                {
                    { 6, "4901234567806", 6, 65000m, "Thớt nhựa kháng khuẩn kháng mùi", 80 },
                    { 7, "4901234567807", 7, 30000m, "Túi lưới giặt đồ lót máy giặt", 140 },
                    { 8, "4901234567808", 8, 40000m, "Gương trang điểm gấp gọn bỏ túi", 110 },
                    { 9, "4901234567809", 9, 55000m, "Bát ăn hình mèo ngộ nghĩnh", 70 },
                    { 10, "4901234567810", 10, 85000m, "Quạt nhựa mini cầm tay chạy pin", 60 },
                    { 11, "4901234567811", 11, 45000m, "Giá đỡ điện thoại để bàn bằng gỗ", 130 },
                    { 12, "4901234567812", 12, 28000m, "Trà xanh không đường Oi Ocha", 220 },
                    { 13, "4901234567813", 13, 60000m, "Hộp chia sữa bột 3 tầng cho bé", 50 },
                    { 14, "4901234567814", 14, 50000m, "Túi rút đựng giày thể thao du lịch", 95 },
                    { 15, "4901234567815", 15, 75000m, "Dây đèn LED đom đóm trang trí phòng", 100 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_CustomerId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 15);

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Bánh kẹo & Đồ ăn vặt", "Snack, bánh quy, kẹo dẻo" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Nước giải khát & Trà", "Nước ngọt, nước khoáng, trà" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Sữa & Sản phẩm từ sữa", "Sữa tươi, sữa chua, phô mai" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Mì gói & Thực phẩm ăn liền", "Mì ăn liền, phở khô, cháo gói" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5,
                columns: new[] { "CategoryName", "Description" },
                values: new object[] { "Gia vị & Dầu ăn", "Nước mắm, hạt nêm, dầu thực vật" });
        }
    }
}
