# Phát triển Giải pháp Phần mềm Bán lẻ và Kiểm soát Hàng tồn kho tự động

## Cửa hàng Đồ dùng Tiện ích Nhật Daiso Mini

Ứng dụng quản lý hoạt động bán lẻ cho cửa hàng tiện ích Daiso Mini, gồm API viết bằng ASP.NET Core, cơ sở dữ liệu SQL Server và ứng dụng quản lý trên WinForms. Hệ thống hỗ trợ quản lý sản phẩm, bán hàng tại quầy, theo dõi hóa đơn, khách hàng, tồn kho và báo cáo doanh thu.

> Đây là dự án học tập mô phỏng hoạt động cửa hàng; không phải sản phẩm chính thức hay có liên kết với thương hiệu Daiso.

## Mục lục

- [Tính năng](#tính-năng)
- [Công nghệ sử dụng](#công-nghệ-sử-dụng)
- [Kiến trúc dự án](#kiến-trúc-dự-án)
- [Yêu cầu hệ thống](#yêu-cầu-hệ-thống)
- [Cài đặt và chạy](#cài-đặt-và-chạy)
- [Một số API chính](#một-số-api-chính)
- [Phân quyền](#phân-quyền)
- [Luồng demo](#luồng-demo)
- [Tác giả](#tác-giả)

## Tính năng

### Bán hàng tại quầy (POS)

- Tìm sản phẩm bằng mã vạch; thêm sản phẩm vào giỏ hàng và cộng dồn số lượng khi quét trùng.
- Tính tổng tiền, điểm thưởng và tiền thối lại.
- Thanh toán đơn hàng thông qua API; kiểm tra tồn kho và thông tin khách hàng ở phía máy chủ.
- Hỗ trợ đổi điểm thưởng để giảm số tiền thanh toán.
- Ghi nhận hóa đơn, chi tiết hóa đơn, số lượng tồn kho và điểm khách hàng trong quy trình giao dịch.

### Sản phẩm và tồn kho

- Xem, tìm kiếm và lọc danh mục sản phẩm.
- Nhân viên thu ngân được xem danh sách sản phẩm ở chế độ chỉ đọc; giá nhập không được trả về cho vai trò này.
- Người có quyền quản trị được thêm, cập nhật và xóa sản phẩm.
- Làm nổi bật mặt hàng sắp hết khi tồn kho không quá 10.
- Hỗ trợ xuất danh sách sản phẩm ra CSV.

### Hóa đơn và khách hàng

- Xem danh sách hóa đơn và chi tiết từng hóa đơn.
- Thu ngân chỉ xem hóa đơn do tài khoản của mình lập; người quản lý có quyền phù hợp có thể xem toàn bộ.
- Quản lý thông tin khách hàng và điểm thưởng theo quyền được cấp.

### Dashboard và báo cáo

- Dashboard gồm doanh thu trong ngày, số hóa đơn, khách hàng mới và số mặt hàng sắp hết.
- Báo cáo doanh thu theo khoảng ngày và theo thu ngân.
- Thống kê sản phẩm bán chạy.
- Xuất dữ liệu hóa đơn theo khoảng thời gian.

### Đăng nhập và giao diện

- Đăng nhập API và xác thực bằng JWT.
- `ApiClientService` dùng chung để gọi API và tự đính kèm Bearer Token.
- Giao diện WinForms có menu điều hướng bên trái, tiêu đề phía trên và nhúng màn hình con trong vùng làm việc trung tâm.
- Các nút chức năng được hiển thị theo vai trò đăng nhập.

## Công nghệ sử dụng

- **Backend:** ASP.NET Core Web API, .NET 8
- **Desktop client:** Windows Forms, .NET 8
- **Cơ sở dữ liệu:** Microsoft SQL Server
- **ORM:** Entity Framework Core
- **Xác thực:** JWT Bearer
- **Truy vấn dữ liệu:** Entity Framework Core LINQ và ADO.NET ở một số nghiệp vụ
- **Giao tiếp:** REST API, JSON, `HttpClient`

## Kiến trúc dự án

```text
.
├── Controllers/                 # API đăng nhập, sản phẩm, đơn hàng, báo cáo...
├── Data/                        # DbContext và cấu hình dữ liệu
├── Migrations/                  # Migration của Entity Framework Core
├── Models/                      # Entity và DTO
├── MiniSupermarket.WinForms/    # Ứng dụng desktop WinForms
├── Properties/                  # Cấu hình chạy API
├── MiniSupermarket.API.csproj
└── README.md
```

## Yêu cầu hệ thống

- Windows
- .NET 8 SDK
- SQL Server hoặc SQL Server Express
- Visual Studio 2022 hoặc .NET CLI

## Cài đặt và chạy

### 1. Lấy mã nguồn

```bash
git clone <URL_REPOSITORY_CUA_BAN>
cd <TEN_THU_MUC_DU_AN>
```

### 2. Cấu hình SQL Server và JWT

API cần có các cấu hình `ConnectionStrings:DefaultConnection`, `JwtSettings:Secret` và `Cors:AllowedOrigins`. Không đưa mật khẩu hoặc JWT secret thật lên GitHub. Có thể đặt cấu hình cục bộ bằng User Secrets từ thư mục chứa `MiniSupermarket.API.csproj`:

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=.\SQLEXPRESS;Database=MiniSupermarket;Trusted_Connection=True;TrustServerCertificate=True;"
dotnet user-secrets set "JwtSettings:Secret" "<CHUOI_BI_MAT_DAI_VA_NGAU_NHIEN>"
```

Nếu dùng máy chủ hoặc database khác, hãy thay giá trị chuỗi kết nối cho phù hợp. Cấu hình `Cors:AllowedOrigins` trong `appsettings.json` nếu API được gọi từ một ứng dụng web ở origin khác.

### 3. Chạy API

```powershell
dotnet run --project .\MiniSupermarket.API.csproj --launch-profile https
```

API chạy theo profile HTTPS đã cấu hình trong `Properties/launchSettings.json`; Swagger được bật trong môi trường Development. Khi khởi động, ứng dụng thử áp dụng các migration và chuẩn bị dữ liệu mẫu. SQL Server cần chạy và có thể truy cập được.

### 4. Chạy ứng dụng WinForms

Mở terminal thứ hai tại thư mục gốc:

```powershell
dotnet run --project .\MiniSupermarket.WinForms\MiniSupermarket.WinForms.csproj
```

WinForms gọi các địa chỉ API được khai báo trong `MiniSupermarket.WinForms/ApiClientService.cs`. Nếu thay đổi cổng hoặc giao thức của API, cập nhật danh sách địa chỉ tại file này cho phù hợp.

## Một số API chính

Các endpoint được bảo vệ yêu cầu JWT trong header:

```http
Authorization: Bearer <JWT_TOKEN>
```

| Phương thức | Endpoint | Mô tả |
|---|---|---|
| `POST` | `/api/auth/login` | Đăng nhập và nhận JWT |
| `GET` | `/api/products` | Danh sách sản phẩm |
| `GET` | `/api/products/paged` | Danh sách sản phẩm có phân trang và tìm kiếm |
| `GET` | `/api/products/barcode/{barcode}` | Tra cứu sản phẩm theo mã vạch |
| `POST` | `/api/orders/checkout` | Thanh toán và tạo hóa đơn |
| `GET` | `/api/orders` | Lịch sử hóa đơn theo quyền người dùng |
| `GET` | `/api/reports/dashboard-summary` | Số liệu tổng quan dashboard |
| `GET` | `/api/reports/sales-by-day` | Doanh thu theo ngày |
| `GET` | `/api/reports/top-products` | Danh sách sản phẩm bán chạy |
| `GET` | `/api/reports/orders-export` | Dữ liệu hóa đơn phục vụ xuất báo cáo |

Ví dụ truy vấn danh sách sản phẩm phân trang:

```http
GET /api/products/paged?keyword=Coca&pageNumber=1&pageSize=10
```

## Phân quyền

- **Admin / Manager / Supervisor:** truy cập các màn hình quản trị và báo cáo theo quyền được cấp.
- **Cashier:** sử dụng POS, xem sản phẩm ở chế độ chỉ đọc và xem hóa đơn do chính mình lập.
- API kiểm tra quyền ở phía máy chủ; ẩn nút trên giao diện không thay thế cho xác thực và phân quyền API.

## Luồng demo

1. Cấu hình SQL Server và JWT, sau đó chạy API.
2. Chạy WinForms và đăng nhập bằng tài khoản đã được tạo trong cơ sở dữ liệu.
3. Với tài khoản quản lý, xem danh mục sản phẩm, dashboard và báo cáo.
4. Đăng xuất rồi đăng nhập bằng tài khoản thu ngân; xác nhận chỉ hiển thị các chức năng POS, xem sản phẩm và đơn hàng được cấp.
5. Tạo một đơn hàng thử tại POS, kiểm tra hóa đơn, tồn kho và điểm khách hàng.
6. Mở lịch sử hóa đơn để xem hóa đơn và các dòng sản phẩm.

## Tác giả

- **Sinh viên:** Nguyen Thien Phuoc
- **Mã sinh viên:** 2124110282
- **Lớp:** CCQ2411C
- **Môn học:** Lap Trinh Ung Dung

## Giới thiệu ngắn để đăng GitHub

Bạn có thể sao chép phần dưới đây vào phần **About** của repository hoặc dùng làm mô tả khi giới thiệu dự án:

> **Phát triển Giải pháp Phần mềm Bán lẻ và Kiểm soát Hàng tồn kho tự động cho Cửa hàng Đồ dùng Tiện ích Nhật Daiso Mini.** Dự án xây dựng hệ thống quản lý bán lẻ gồm ASP.NET Core Web API, ứng dụng WinForms và SQL Server. Các chức năng chính bao gồm đăng nhập JWT, phân quyền người dùng, quản lý sản phẩm và tồn kho, bán hàng POS, quản lý hóa đơn và khách hàng, tích điểm/đổi điểm, dashboard KPI và báo cáo doanh thu.

**Mô tả ngắn (GitHub repository description):**

```text
Ứng dụng quản lý bán lẻ Daiso Mini với ASP.NET Core Web API, WinForms, SQL Server, POS, quản lý tồn kho, hóa đơn và báo cáo doanh thu.
```
