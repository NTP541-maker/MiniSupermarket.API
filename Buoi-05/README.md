# Mini Supermarket Daiso Mini Management System

## Thông tin sinh viên
- Họ tên: Nguyen Tran Ngoc Thuong
- MSSV: 2124110088
- Lớp: CCQ2411C

## Đề tài
Phát triển Giải pháp Phần mềm Bán lẻ và Kiểm soát Hàng tồn kho tự động cho cửa hàng Đồ dùng Tiện ích Nhật Daiso Mini.

## Mô tả dự án
Dự án này xây dựng hệ thống quản lý bán hàng và kiểm soát kho cho cửa hàng tiện ích mini theo mô hình Daiso Mini. Hệ thống hỗ trợ:
- Quản lý danh mục và sản phẩm
- Theo dõi tồn kho theo từng mặt hàng
- Cảnh báo tự động khi sản phẩm sắp hết hàng
- Quản lý bán hàng qua POS
- Theo dõi doanh thu và báo cáo nhanh
- Quản lý khách hàng và quyền truy cập người dùng

## Công nghệ sử dụng
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger UI
- WinForms Client

## Chức năng chính
1. Quản lý sản phẩm và danh mục hàng hóa
2. Tìm kiếm sản phẩm theo tên, mã vạch và nhóm hàng
3. Theo dõi tồn kho và cảnh báo hàng thấp
4. Xử lý thanh toán POS với kiểm tra tồn kho
5. Báo cáo doanh thu theo nhân viên
6. Quản lý người dùng và phân quyền

## Cách chạy
1. Cài đặt SQL Server và cấu hình chuỗi kết nối trong `appsettings.json`.
2. Khởi động project bằng Visual Studio hoặc `dotnet run`.
3. Truy cập Swagger tại `/swagger`.

## Lưu ý
Dữ liệu mẫu đã được điều chỉnh để phù hợp với mô hình cửa hàng đồ dùng tiện ích Nhật Daiso Mini, thay vì dữ liệu siêu thị tổng hợp truyền thống.
