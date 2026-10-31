# Giải pháp phần mềm bán lẻ và kiểm soát hàng tồn kho tự động

## Cửa hàng Đồ dùng Tiện ích Nhật Daiso Mini

## Thông tin sinh viên

- Họ tên: Nguyen Thien Phuoc
- MSSV: 2124110282
- Lớp: CCQ2411C

## Giới thiệu

Dự án xây dựng phần mềm hỗ trợ hoạt động bán lẻ tại cửa hàng đồ dùng tiện ích Nhật Daiso Mini. Hệ thống gồm API quản lý dữ liệu và ứng dụng desktop Windows Forms dành cho nhân viên cửa hàng.

Các nghiệp vụ chính gồm quản lý sản phẩm và danh mục, tra cứu hàng hóa, bán hàng tại quầy (POS), quản lý khách hàng, tự động cập nhật số lượng tồn sau thanh toán, cảnh báo mặt hàng đạt ngưỡng tồn kho tối thiểu và xem báo cáo doanh thu theo thu ngân.

## Chức năng

- **Sản phẩm và danh mục:** thêm, xem, cập nhật, xóa và tìm kiếm sản phẩm/danh mục; tra cứu sản phẩm theo mã vạch.
- **Kiểm soát tồn kho:** lưu số lượng tồn và ngưỡng tồn tối thiểu của từng sản phẩm; cung cấp danh sách sản phẩm sắp hết hàng khi số lượng tồn nhỏ hơn hoặc bằng ngưỡng.
- **Bán hàng POS:** tạo hóa đơn từ giỏ hàng; kiểm tra sản phẩm và tồn kho; ghi nhận hóa đơn, chi tiết hóa đơn và trừ tồn kho trong một giao dịch cơ sở dữ liệu.
- **Khách hàng:** quản lý, tìm kiếm khách hàng và điểm thưởng; cộng điểm thưởng khi thanh toán.
- **Đăng nhập và phân quyền:** xác thực bằng JWT; giới hạn một số nghiệp vụ theo vai trò, chẳng hạn thanh toán cho Admin/Cashier và báo cáo doanh thu cho Admin.
- **Báo cáo:** tổng hợp số hóa đơn, doanh thu và điểm thưởng theo thu ngân.
- **Ứng dụng desktop:** giao diện WinForms gồm các màn hình đăng nhập, POS, sản phẩm, danh mục, khách hàng, vai trò và phân tích.

## Công nghệ

- C# và .NET 8
- ASP.NET Core Web API
- Windows Forms (WinForms)
- Entity Framework Core 8 và SQL Server
- ADO.NET cho một số thao tác POS, tra cứu và báo cáo
- JWT Bearer Authentication
- Swagger / OpenAPI

## Cấu trúc dự án

```text
.
├── Controllers/                 # API đăng nhập, sản phẩm, danh mục, khách hàng, POS, báo cáo
├── Data/                        # SupermarketDbContext và cấu hình dữ liệu
├── Migrations/                  # Migration cơ sở dữ liệu Entity Framework Core
├── Models/                      # Các mô hình sản phẩm, khách hàng, hóa đơn và dữ liệu liên quan
├── MiniSupermarket.WinForms/    # Ứng dụng desktop Windows Forms
├── MiniSupermarket.API.csproj   # Dự án Web API
└── MiniSupermarket.API.sln      # Solution gồm API và WinForms
```

## Một số API chính

Các API nghiệp vụ yêu cầu JWT, trừ endpoint đăng nhập.

| Phương thức | Endpoint | Mô tả |
|---|---|---|
| `POST` | `/api/auth/login` | Đăng nhập và nhận JWT |
| `GET` | `/api/products` | Lấy danh sách sản phẩm |
| `GET` | `/api/products/low-stock` | Lấy sản phẩm chạm ngưỡng tồn tối thiểu |
| `GET` | `/api/products/search?keyword={tu_khoa}` | Tìm sản phẩm theo tên, mã vạch hoặc danh mục |
| `GET` | `/api/products/barcode/{barcode}` | Tra cứu theo mã vạch |
| `GET` | `/api/categories` | Lấy danh sách danh mục |
| `GET` | `/api/customers` | Lấy danh sách khách hàng |
| `POST` | `/api/checkout` | Thanh toán giỏ hàng POS và cập nhật tồn kho |
| `GET` | `/api/reports/revenue-by-cashier` | Báo cáo doanh thu theo thu ngân |

Mở Swagger trong môi trường Development để xem chi tiết request/response và các endpoint hiện có.

## Yêu cầu môi trường

- Windows và Visual Studio 2022 hoặc .NET 8 SDK.
- SQL Server.
- Cấu hình chuỗi kết nối tới SQL Server có quyền tạo/cập nhật cơ sở dữ liệu.

## Cài đặt và chạy

1. Clone repository và mở `MiniSupermarket.API.sln` bằng Visual Studio, hoặc mở terminal tại thư mục chứa solution.
2. Cấu hình chuỗi kết nối cho API. Không sử dụng chuỗi kết nối máy phát triển đang có trong `appsettings.json`; hãy thay bằng cấu hình SQL Server của bạn. Có thể đặt bằng User Secrets:

   ```powershell
   dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=TEN_MAY_CHU;Database=TiemTapHoaDaisoMini;Trusted_Connection=True;TrustServerCertificate=True;" --project MiniSupermarket.API.csproj
   dotnet user-secrets set "JwtSettings:Secret" "THAY_BANG_CHUOI_BI_MAT_DAI_VA_NGAU_NHIEN" --project MiniSupermarket.API.csproj
   ```

3. Chạy API:

   ```powershell
   dotnet run --project MiniSupermarket.API.csproj
   ```

   Khi khởi động, API áp dụng các migration hiện có vào cơ sở dữ liệu. Swagger được bật trong môi trường Development; địa chỉ cụ thể được hiển thị trong output của ứng dụng.

4. Chạy ứng dụng WinForms trên Windows, bằng Visual Studio hoặc:

   ```powershell
   dotnet run --project MiniSupermarket.WinForms/MiniSupermarket.WinForms.csproj
   ```

   WinForms hiện cấu hình địa chỉ API mặc định là `https://localhost:7035/api/` trong `MiniSupermarket.WinForms/ApiClientService.cs`. Nếu API chạy ở địa chỉ khác, cập nhật địa chỉ này để ứng dụng desktop kết nối đúng API.

## Dữ liệu mẫu và lưu ý

- Cấu hình dữ liệu có các danh mục và sản phẩm mẫu theo nhóm hàng tiện ích như nhà bếp, vệ sinh, chăm sóc cá nhân, lưu trữ, văn phòng, trang trí và mẹ & bé.
- Chức năng đăng nhập hiện phục vụ mục đích demo và sử dụng tài khoản mẫu được khai báo trong mã nguồn. Cần thay thế cơ chế/tài khoản demo, cấu hình JWT và chứng chỉ phù hợp trước khi triển khai thực tế.
- Ngưỡng tồn kho thấp được lưu theo từng sản phẩm. Việc bán hàng tự động trừ kho khi thanh toán thành công; dự án hiện tập trung vào nghiệp vụ bán hàng và theo dõi tồn kho theo các chức năng được triển khai.
