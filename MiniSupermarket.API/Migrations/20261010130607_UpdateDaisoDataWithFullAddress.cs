using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniSupermarket.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDaisoDataWithFullAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Address",
                value: "123 Đường Lê Lợi, Phường Bến Thành, Quận 1, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Address",
                value: "45 Đường Nam Kỳ Khởi Nghĩa, Phường Võ Thị Sáu, Quận 3, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Address",
                value: "78 Đường Trần Hưng Đạo, Phường 2, Quận 5, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "Address",
                value: "12 Đường Nguyễn Thị Thập, Phường Tân Phú, Quận 7, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "Address",
                value: "90 Đường Thành Thái, Phường 14, Quận 10, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                column: "Address",
                value: "156 Đường Võ Văn Ngân, Phường Linh Chiểu, Thành phố Thủ Đức, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                column: "Address",
                value: "234 Đường Bạch Đằng, Phường 24, Quận Bình Thạnh, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                column: "Address",
                value: "56 Đường Phan Xích Long, Phường 2, Quận Phú Nhuận, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                column: "Address",
                value: "89 Đường Cộng Hòa, Phường 4, Quận Tân Bình, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                column: "Address",
                value: "345 Đường Nguyễn Oanh, Phường 17, Quận Gò Vấp, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                column: "Address",
                value: "67 Đường Tôn Đản, Phường 8, Quận 4, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                column: "Address",
                value: "120 Đường Phạm Hùng, Phường 4, Quận 8, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                column: "Address",
                value: "34 Đường Lạc Long Quân, Phường 3, Quận 11, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14,
                column: "Address",
                value: "210 Đường Trương Phước Phan, Phường Bình Trị Đông, Quận Tân Phú, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15,
                column: "Address",
                value: "567 Đường Quốc Lộ 1A, Phường Bình Hưng Hòa B, Quận Bình Tân, TP.HCM");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 1,
                column: "Address",
                value: "Quận 1, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 2,
                column: "Address",
                value: "Quận 3, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 3,
                column: "Address",
                value: "Quận 5, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 4,
                column: "Address",
                value: "Quận 7, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 5,
                column: "Address",
                value: "Quận 10, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 6,
                column: "Address",
                value: "Thủ Đức, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 7,
                column: "Address",
                value: "Bình Thạnh, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 8,
                column: "Address",
                value: "Phú Nhuận, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 9,
                column: "Address",
                value: "Tân Bình, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 10,
                column: "Address",
                value: "Gò Vấp, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 11,
                column: "Address",
                value: "Quận 4, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 12,
                column: "Address",
                value: "Quận 8, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 13,
                column: "Address",
                value: "Quận 11, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 14,
                column: "Address",
                value: "Tân Phú, TP.HCM");

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "CustomerId",
                keyValue: 15,
                column: "Address",
                value: "Bình Tân, TP.HCM");
        }
    }
}
