# PHÁT TRIỂN GIẢI PHÁP PHẦN MỀM BÁN LẺ VÀ KIỂM SOÁT HÀNG TỒN KHO TỰ ĐỘNG
## Cửa hàng Đồ dùng Tiện ích Nhật Daiso Mini

### Thông tin sinh viên
- **Họ và tên:** Nguyễn Thiên Phước
- **MSSV:** 2124110282
- **Lớp học phần:** CCQ2411C
- **Môn học:** Lập trình Ứng dụng .NET Core (229162)

---

## 1. Giới thiệu đề tài

Dự án xây dựng phần mềm hỗ trợ hoạt động bán lẻ tại cửa hàng đồ dùng tiện ích Nhật Daiso Mini. Hệ thống gồm Web API làm backend, SQL Server lưu trữ dữ liệu nghiệp vụ và ứng dụng Windows Forms cho nhân viên thao tác.

Các nhóm nghiệp vụ được thể hiện trong mã nguồn hiện tại:

- Quản lý nhóm hàng, sản phẩm, mã vạch và số lượng tồn kho.
- Tra cứu sản phẩm theo mã vạch, từ khóa hoặc nhóm hàng.
- Quản lý khách hàng và thông tin thành viên.
- Màn hình POS tạo đơn bán; API xử lý đơn có kiểm tra tồn kho, trừ số lượng bán và ghi nhật ký xuất kho.
- Quản lý tài khoản/vai trò và đăng nhập bằng JWT.
- Màn hình báo cáo nhanh trên WinForms.

> **Phạm vi kiểm soát kho hiện có:** API tạo đơn bán tại `POST /api/orders` kiểm tra số lượng tồn, trừ kho và ghi `InventoryLogs` trong cùng transaction. Chưa có API nhập hàng/điều chỉnh kho riêng hoặc cảnh báo tồn kho thấp tự động; số tồn ban đầu có thể được thiết lập khi tạo/cập nhật sản phẩm.

## 2. Công nghệ sử dụng

- C# và .NET 8
- ASP.NET Core Web API
- Entity Framework Core 8, SQL Server
- EF Core Migrations và LINQ
- Swagger / OpenAPI
- Xác thực JWT cho API
- Windows Forms, `HttpClient` và `System.Net.Http.Json`
- Visual Studio 2022

## 3. Cấu trúc solution

```text
MiniSuperMarket_NguyenThienPhuoc.sln
├── MiniSupermarket.API/
│   ├── Controllers/       # API xác thực, nhóm hàng, sản phẩm, khách hàng, đơn hàng, người dùng, vai trò
│   ├── Data/              # SupermarketDbContext và UserStore
│   ├── DTOs/              # DTO dữ liệu trao đổi với client
│   ├── Migrations/        # Migration InitDB và model snapshot
│   ├── Models/            # Product, Category, Customer, Order, InventoryLog...
│   ├── appsettings.json   # Chuỗi kết nối SQL Server và cấu hình JWT
│   └── Program.cs         # Đăng ký DbContext, JWT, Swagger và controllers
└── MiniSupermarket.WinForms/
    ├── FormPOS.cs
    ├── FormProductManagement.cs
    ├── FormCategoryManagement.cs
    ├── FormCustomerManagement.cs
    ├── FormUserManagement.cs
    ├── FormRoleManagement.cs
    ├── FormQuickReport.cs
    └── SessionManager.cs  # HttpClient dùng chung và thông tin phiên đăng nhập
```

## 4. Mô hình dữ liệu

`SupermarketDbContext` khai báo các tập dữ liệu: `Brands`, `Categories`, `Products`, `Customers`, `Promotions`, `Suppliers`, `Users`, `Orders`, `OrderDetails` và `InventoryLogs`.

Các thực thể chính:

- **Category:** mã nhóm hàng, tên, mô tả và trạng thái hoạt động; quan hệ một-nhiều với sản phẩm.
- **Product:** tên, mã vạch, giá bán, số lượng tồn và mã nhóm hàng. Giá sử dụng `decimal(18,2)`.
- **Customer:** tên, số điện thoại, địa chỉ, điểm thưởng và hạng thành viên.
- **Order / OrderDetail:** thông tin đơn bán và các dòng sản phẩm, số lượng, đơn giá.
- **InventoryLog:** sản phẩm, loại giao dịch, thay đổi số lượng, thời gian, thông tin lô/hạn dùng, nhà cung cấp và ghi chú.
- **Brand, Supplier, Promotion, User:** các thực thể bổ trợ cho thương hiệu, nhà cung cấp, khuyến mãi và tài khoản.

`OnModelCreating()` cấu hình dữ liệu mẫu bằng `HasData()` cho một số thực thể, bao gồm sản phẩm, nhóm hàng, khách hàng và thương hiệu.

## 5. Cấu hình và khởi chạy

### Yêu cầu

- Windows và Visual Studio 2022 (hoặc .NET 8 SDK).
- SQL Server có thể truy cập từ máy chạy API.
- Restore các NuGet packages của solution trước khi build.

### Cấu hình SQL Server

Trong `MiniSupermarket.API/appsettings.json`, chỉnh `ConnectionStrings:DefaultConnection` cho đúng máy SQL Server. Cấu hình hiện tại dùng Windows Authentication và database `TiemTapHoaDaisoMini`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<TEN_SQL_SERVER>;Database=TiemTapHoaDaisoMini;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Thay `<TEN_SQL_SERVER>` bằng tên server/instance trên máy đang chạy. Nếu không có `DefaultConnection`, `Program.cs` dùng fallback LocalDB với database `MiniSupermarketDb_TaVanThang`. Không đưa mật khẩu hoặc khóa bí mật thật vào Git; cấu hình JWT nên được thay bằng khóa riêng cho môi trường triển khai.

### Khởi chạy

1. Mở `MiniSuperMarket_NguyenThienPhuoc.sln` bằng Visual Studio.
2. Chạy `MiniSupermarket.API` trước. Launch profile HTTP lắng nghe tại `http://localhost:5000`; profile HTTPS dùng `https://localhost:5001` và `http://localhost:5000`.
3. Trong môi trường Development, mở Swagger tại `http://localhost:5000/swagger` (hoặc URL HTTPS tương ứng).
4. Chạy `MiniSupermarket.WinForms`. Các HttpClient trong WinForms hiện cấu hình `http://localhost:5000/api/`, vì vậy API cần chạy tại cổng 5000 trừ khi cập nhật BaseAddress tương ứng.

## 6. Database và EF Core Migrations

Dự án đã có migration `InitDB` trong thư mục `MiniSupermarket.API/Migrations`.

Trong Package Manager Console, chọn `MiniSupermarket.API` làm Default project rồi có thể xem và áp dụng migration hiện có:

```powershell
Get-Migration
Update-Database
```

Chỉ tạo migration mới sau khi thay đổi model và xác nhận migration cần thiết chưa tồn tại:

```powershell
Add-Migration <TenMigration>
Update-Database
```

**Lưu ý theo code hiện tại:** `Program.cs` gọi `context.Database.EnsureCreated()` khi API khởi động. `EnsureCreated()` tạo database/schema nếu database chưa có, nhưng không áp dụng các migration đang chờ và không thay thế `Migrate()`. Tránh dùng lẫn hai cơ chế trên cùng một database chưa được kiểm tra; nếu chuyển sang quy trình migration hoàn toàn, cần điều chỉnh cách khởi tạo database và sao lưu dữ liệu trước khi thay đổi.

## 7. API hiện có

Các route dưới đây lấy từ controller hiện tại trong dự án:

| Nhóm | Endpoint | Chức năng |
|---|---|---|
| Auth | `POST /api/auth/login` | Đăng nhập và nhận JWT |
| Categories | `GET /api/categories` | Lấy danh sách nhóm hàng |
| Categories | `GET /api/categories/{id}` | Lấy nhóm hàng theo mã |
| Categories | `GET /api/categories/search?keyword=...` | Tìm nhóm hàng theo tên |
| Categories | `POST /api/categories`, `PUT /api/categories/{id}`, `DELETE /api/categories/{id}` | Thêm, cập nhật, xóa nhóm hàng |
| Products | `GET /api/products`, `GET /api/products/{id}` | Lấy danh sách/chi tiết sản phẩm |
| Products | `GET /api/products/barcode/{barcode}` | Tra cứu bằng mã vạch |
| Products | `GET /api/products/search?keyword=...&categoryId=...` | Tìm theo tên/mã vạch và lọc nhóm hàng |
| Products | `POST /api/products`, `PUT /api/products/{id}`, `DELETE /api/products/{id}` | CRUD sản phẩm |
| Customers | `GET /api/customers`, `GET /api/customers/{id}` | Lấy danh sách/chi tiết khách hàng |
| Customers | `GET /api/customers/by-phone/{phone}` | Tra cứu theo số điện thoại |
| Customers | `GET /api/customers/search?keyword=...` | Tìm theo tên hoặc số điện thoại |
| Customers | `POST /api/customers`, `PUT /api/customers/{id}`, `DELETE /api/customers/{id}` | CRUD khách hàng |
| Orders | `POST /api/orders` | Tạo đơn, kiểm tra và trừ tồn kho, ghi log xuất kho |
| Roles | `GET/POST /api/roles`, `GET/PUT/DELETE /api/roles/{id}` | Thao tác với danh sách vai trò |
| Users | `GET /api/users`, `GET /api/users/{id}`, `POST /api/users` | Xem và tạo tài khoản |
| Users | `PUT /api/users/{id}/toggle-lock`, `POST /api/users/{id}/reset-password` | Khóa/mở tài khoản và đặt lại mật khẩu |

Một số endpoint Categories được giới hạn quyền bằng role, ví dụ thao tác ghi yêu cầu `Admin`, `Cashier` hoặc `Warehouse`, còn xóa yêu cầu `Admin`. API dùng `ToListAsync`, `FindAsync`, `SaveChangesAsync` và `AsNoTracking` ở các truy vấn chỉ đọc phù hợp.

## 8. Luồng bán hàng và kiểm soát tồn kho

Trong API `POST /api/orders`, hệ thống:

1. Kiểm tra yêu cầu đơn hàng có sản phẩm.
2. Mở transaction cơ sở dữ liệu.
3. Kiểm tra từng sản phẩm tồn tại và đủ số lượng.
4. Trừ `Product.StockQuantity` theo số lượng bán.
5. Tạo `OrderDetail` và `InventoryLog` loại `EXPORT`.
6. Lưu đơn và thay đổi tồn kho; rollback nếu xảy ra lỗi.

WinForms POS có thao tác tìm sản phẩm qua mã vạch và tìm khách hàng qua số điện thoại. Tuy nhiên, hiện tại có hai điểm chưa đồng bộ giữa client và API:

- `FormPOS` gửi thanh toán tới `POST /api/orders/checkout`, trong khi `OrdersController` chỉ khai báo `POST /api/orders`.
- `FormQuickReport` gọi `GET /api/orders/report`, nhưng `OrdersController` hiện chưa có route báo cáo.

Vì vậy, cần đồng bộ route client/API trước khi nghiệm thu thanh toán POS và báo cáo từ WinForms.

## 9. Kiểm thử nghiệm thu

- Khởi động API, mở Swagger và thử các route đọc/ghi.
- Xác nhận dữ liệu sản phẩm, khách hàng, đơn hàng và nhật ký kho trong đúng database SQL Server.
- Kiểm tra tìm sản phẩm bằng barcode và lọc theo nhóm hàng.
- Gửi đơn có số lượng hợp lệ để xác nhận tồn kho giảm và có log `EXPORT`.
- Gửi đơn vượt quá tồn kho để xác nhận API từ chối và không lưu giao dịch dở dang.
- Chạy WinForms để kiểm tra tải dữ liệu, chọn dòng, tìm kiếm và các thao tác CRUD.
- Kiểm tra lại các route thanh toán/báo cáo chưa đồng bộ nêu ở trên trước khi xác nhận chúng hoạt động.
- Khởi động lại API và kiểm tra dữ liệu đã lưu trong SQL Server vẫn còn.

## 10. Các giới hạn hiện tại cần lưu ý

- `AuthController` xác thực thông tin từ `UserStore.Users` trong bộ nhớ; `UsersController` và `RolesController` cũng thao tác với các danh sách RAM. Vì vậy, người dùng/vai trò tạo trong các màn hình này chưa được lưu bền vững vào các bảng `Users`/`Roles`.
- Có entity và bảng `InventoryLogs`, nhưng chưa có controller riêng để truy vấn nhật ký kho hoặc xử lý nhập hàng/điều chỉnh kho.
- Client gọi `/api/orders/checkout` và `/api/orders/report`, trong khi các route này chưa được khai báo trong API.
- `EnsureCreated()` đang được dùng để khởi tạo database lúc chạy; cơ chế này cần được thống nhất với Migrations như lưu ý ở mục 6.

## 11. Kết luận

Dự án hiện cung cấp nền tảng ứng dụng bán lẻ Daiso Mini với Web API, SQL Server, EF Core và WinForms. Các nghiệp vụ sản phẩm, nhóm hàng, khách hàng và xử lý đơn bán được tổ chức theo mô hình API; API tạo đơn có thể kiểm tra và cập nhật tồn kho tự động, đồng thời ghi nhận lịch sử xuất kho. Các bước tiếp theo là đồng bộ endpoint giữa POS/báo cáo với API, hoàn thiện nhập và điều chỉnh tồn kho, đưa xác thực và quản lý tài khoản/vai trò vào lưu trữ bền vững, rồi thống nhất việc khởi tạo database bằng EF Core Migrations.
