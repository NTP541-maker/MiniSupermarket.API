# Phát triển Giải pháp Phần mềm Bán lẻ và Kiểm soát Hàng tồn kho tự động

## Đề tài: Cửa hàng Đồ dùng Tiện ích Nhật Daiso Mini

**Tên đề tài:** Phát triển giải pháp phần mềm bán lẻ và kiểm soát hàng tồn kho tự động cho cửa hàng đồ dùng tiện ích Nhật Daiso Mini  
**Người thực hiện:** [Tên sinh viên]  
**Mã sinh viên:** [Mã số sinh viên]  
**Lớp:** [Tên lớp]  
**Năm học:** 2026

---

## 1. Tổng quan đề tài

Cửa hàng tiện ích Nhật Daiso Mini là mô hình cửa hàng bán lẻ nhỏ, quy mô vừa, chuyên kinh doanh các mặt hàng gia dụng, đồ dùng nhà bếp, tiện ích sinh hoạt, sản phẩm giá rẻ, hàng nhập khẩu và hàng liệu theo mùa. Với số lượng mặt hàng lớn nhưng không đồng nhất, việc quản lý bán hàng, theo dõi kho, cập nhật tồn kho và xuất nhập hàng theo thời gian thực đang trở thành vấn đề then chốt đối với hoạt động kinh doanh.

Hiện nay, nhiều cửa hàng tiện ích nhỏ vẫn đang quản lý bằng Excel, giấy tờ thủ công hoặc phần mềm không đồng bộ. Điều này dẫn đến các vấn đề như:

- Sai số trong tính tồn kho
- Khó追 theo giá nhập, giá bán và lợi nhuận
- Không có cảnh báo hàng sắp hết, hết hàng
- Giao dịch bán hàng chậm, thiếu chính xác
- Báo cáo doanh thu, sản phẩm bán chạy và lợi nhuận không cập nhật kịp thời

Vì vậy, đề tài tập trung xây dựng một hệ thống phần mềm bán lẻ và kiểm soát hàng tồn kho tự động, cho phép cửa hàng Daiso Mini quản lý hiệu quả toàn bộ quy trình từ nhập hàng, tồn kho, bán hàng, khách hàng, đến báo cáo và phân quyền người dùng.

---

## 2. Mục tiêu của hệ thống

### 2.1 Mục tiêu chung
Xây dựng một giải pháp phần mềm bán lẻ hiện đại, hỗ trợ cửa hàng quản lý sản phẩm, kho hàng, giao dịch bán hàng và báo cáo thống kê theo thời gian thực, đồng thời giúp giảm sai sót trong vận hành và tăng hiệu quả quản lý.

### 2.2 Mục tiêu cụ thể
- Quản lý danh mục sản phẩm và nhóm hàng theo từng loại tiện ích
- Theo dõi số lượng tồn kho thực tế và cập nhật tự động sau mỗi giao dịch
- Quản lý hóa đơn bán hàng nhanh chóng qua hệ thống POS
- Cảnh báo sản phẩm sắp hết, hết hàng hoặc tăng trưởng doanh thu bất thường
- Hỗ trợ báo cáo doanh thu theo ngày, theo nhân viên, theo danh mục và theo sản phẩm
- Phân quyền người dùng theo vai trò: Admin, Thu ngân, Quản kho
- Tích hợp API RESTful để dễ mở rộng, tích hợp mobile hoặc web trong tương lai

---

## 3. Phạm vi đề tài

### 3.1 Chức năng nghiệp vụ chính
1. Quản lý danh mục và sản phẩm
   - Thêm, sửa, xóa sản phẩm
   - Quản lý mã vạch, tên hàng, giá gốc, giá bán, đơn vị tính, số lượng tồn
   - Phân loại theo ngành hàng: gia dụng, bếp, vệ sinh, lưu trữ, trang trí, trẻ em, vân phong...

2. Quản lý kho hàng
   - Theo dõi số lượng nhập, xuất, tồn kho
   - Tự động cập nhật tồn kho sau khi bán hàng hoặc hủy hóa đơn
   - Cảnh báo mức tồn kho an toàn

3. Bán hàng tại quầy (POS)
   - Chọn sản phẩm, thêm vào giỏ hàng, tính tổng tiền
   - Tự động kiểm tra tồn kho trước khi thanh toán
   - Tạo hóa đơn, lưu khách hàng và nhân viên thu ngân
   - Hỗ trợ thanh toán tiền mặt hoặc các phương thức mở rộng sau này

4. Quản lý khách hàng
   - Lưu thông tin khách hàng
   - Tích lũy điểm thưởng và ưu đãi
   - Theo dõi lịch sử mua hàng

5. Báo cáo thống kê
   - Doanh thu theo ngày, tuần, tháng
   - Sản phẩm bán chạy
   - Tồn kho thấp
   - Báo cáo theo nhân viên thu ngân

6. Phân quyền người dùng
   - Admin: toàn quyền
   - Cashier: bán hàng, xem báo cáo cơ bản
   - Warehouse: quản lý kho, nhập xuất hàng

---

## 4. Phân tích yêu cầu hệ thống

### 4.1 Yêu cầu chức năng
- Hệ thống phải cho phép thao tác CRUD với sản phẩm, khách hàng, danh mục và người dùng
- Hệ thống phải kiểm tra tồn kho trước khi bán hàng
- Hệ thống phải ghi nhận từng hóa đơn và dòng chi tiết hóa đơn
- Hệ thống phải tính toán số lượng tồn kho tự động trên mỗi giao dịch
- Hệ thống phải có báo cáo doanh thu và báo cáo hàng tồn kho
- Hệ thống phải hỗ trợ đăng nhập, phân quyền và bảo mật JWT

### 4.2 Yêu cầu phi chức năng
- Tốc độ phản hồi nhanh, phù hợp môi trường bán lẻ trong giờ cao điểm
- Dễ triển khai, ít phụ thuộc và dễ bảo trì
- Bảo mật tốt, tách quyền truy cập theo vai trò
- Có khả năng mở rộng trong tương lai cho điện thoại, web và POS đa điểm bán

---

## 5. Kiến trúc giải pháp đề xuất

Hệ thống được triển khai theo mô hình 3 lớp kết hợp Web API + Client WinForms + CSDL SQL Server:

- Frontend/Client: WinForms hoặc desktop app để thao tác nhanh tại cửa hàng
- Backend: ASP.NET Core Web API
- CSDL: SQL Server / LocalDB
- ORM: Entity Framework Core
- Xác thực: JWT Bearer
- Quản lý giao dịch: SQL Transaction để đảm bảo tính nhất quán của dữ liệu

### Kiến trúc mô hình
- Presentation Layer: màn hình POS, quản lý kho, báo cáo, quản lý khách hàng
- Application Layer: API RESTful, xử lý nghiệp vụ, kiểm tra tồn kho
- Data Layer: SQL Server, Entity Framework Core, stored procedures

---

## 6. Cấu trúc dữ liệu đề xuất

Hệ thống bao gồm các bảng chính sau:

- Users: thông tin tài khoản, vai trò, trạng thái hoạt động
- Categories: nhóm hàng và danh mục sản phẩm
- Products: thông tin hàng hóa, giá bán, số lượng tồn, mã vạch
- Suppliers: nhà cung cấp
- Customers: khách hàng, điểm thưởng, cấp độ thành viên
- Orders: hóa đơn bán hàng
- OrderDetails: chi tiết từng sản phẩm trong hóa đơn
- InventoryTransactions: phiếu nhập/xuất kho (nếu mở rộng)

Các mối quan hệ chính:
- Category 1 - n Product
- Product 1 - n OrderDetail
- Order 1 - n OrderDetail
- Customer 1 - n Order
- User 1 - n Order

---

## 7. Quy trình nghiệp vụ chính

### 7.1 Quy trình nhập hàng
- Quản kho kiểm tra nhu cầu bổ sung hàng
- Nhập thông tin sản phẩm, số lượng, nhà cung cấp, giá nhập
- Hệ thống cập nhật tồn kho và ghi lịch sử nhập kho

### 7.2 Quy trình bán hàng
- Thu ngân đăng nhập
- Quét mã vạch hoặc tìm sản phẩm trong danh mục
- Thêm sản phẩm vào giỏ hàng
- Kiểm tra tồn kho và tính tiền
- Thanh toán, lưu hóa đơn và cập nhật tồn kho tự động

### 7.3 Quy trình hủy hóa đơn
- Admin có quyền hủy hóa đơn đã tạo
- Hệ thống hoàn trả số lượng hàng về kho và trừ điểm thưởng nếu có

### 7.4 Quy trình báo cáo
- Hệ thống tự động tổng hợp doanh thu, lượng hàng bán, tồn kho thấp, sản phẩm bán chạy
- Hiển thị báo cáo theo ngày và theo nhân viên

---

## 8. Tính năng tự động hóa kiểm soát kho

Đây là điểm nổi bật của giải pháp:

- Mỗi lần thanh toán thành công sẽ trừ trực tiếp số lượng hàng trong kho
- Nếu số lượng đặt mua lớn hơn tồn kho, hệ thống ngăn giao dịch
- Nếu sản phẩm tồn kho nhỏ hơn ngưỡng cảnh báo thì chế độ trạng thái hiển thị là "Sắp hết" hoặc "Cận hạn"
- Hệ thống có thể cảnh báo khi hàng đạt ngưỡng an toàn
- Khi hủy hóa đơn, hàng sẽ được hoàn lại kho tự động để tránh sai lệch dữ liệu

Như vậy, kho được kiểm soát theo cơ chế thời gian thực và giao dịch nhất quán, thay vì cần cập nhật thủ công từng lần.

---

## 9. Công nghệ triển khai

- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / LocalDB
- JWT Authentication
- Swagger UI cho tài liệu API
- WinForms desktop client cho giao diện quản lý
- Repository pattern / controller-based REST API

---

## 10. API tham khảo của hệ thống

Một số endpoint chính trong hệ thống có thể triển khai như sau:

- `POST /api/auth/login` : đăng nhập
- `GET /api/products` : lấy danh sách hàng hóa
- `GET /api/products/barcode/{barcode}` : tra cứu sản phẩm theo mã vạch
- `POST /api/products` : thêm sản phẩm mới
- `PUT /api/products/{id}` : cập nhật sản phẩm
- `GET /api/categories` : danh mục hàng hóa
- `GET /api/customers` : danh sách khách hàng
- `POST /api/checkout` : thực hiện thanh toán POS
- `DELETE /api/checkout/cancel/{orderId}` : hủy hóa đơn
- `GET /api/reports/dashboard-summary` : báo cáo tổng quan
- `GET /api/reports/revenue-by-cashier` : báo cáo doanh thu theo thu ngân

---

## 11. Lợi ích mang lại cho doanh nghiệp

- Tăng tốc độ bán hàng và giảm thời gian xử lý hóa đơn
- Giảm sai sót khi quản lý tồn kho thủ công
- Cập nhật dữ liệu tức thời và dễ dàng kiểm tra
- Giúp quản lý ra quyết định nhanh hơn dựa trên báo cáo thực tế
- Nâng cao chất lượng phục vụ khách hàng và độ tin cậy của dữ liệu

---

## 12. Đánh giá khả năng áp dụng thực tế

Giải pháp này phù hợp với mô hình cửa hàng tiện ích mini, siêu thị quy mô vừa, cửa hàng tiện ích gia dụng, và hệ thống bán lẻ ở khu vực thành phố. Với khả năng mở rộng theo hướng web bán hàng, quản lý chuỗi cửa hàng, tích hợp ERP hoặc CRM, hệ thống có thể phát triển thành nền tảng quản trị toàn diện trong tương lai.

---

## 13. Kết luận

Đề tài “Phát triển Giải pháp Phần mềm Bán lẻ và Kiểm soát Hàng tồn kho tự động cho cửa hàng Đồ dùng Tiện ích Nhật Daiso Mini” là một giải pháp phù hợp với thực tế kinh doanh hiện nay. Hệ thống này không chỉ hỗ trợ bán hàng mà còn giải quyết bài toán quản lý kho, báo cáo doanh thu và tối ưu quy trình vận hành, giúp cửa hàng hoạt động hiệu quả hơn, giảm sai sót và tăng khả năng cạnh tranh trên thị trường bán lẻ.

---

## 14. Gợi ý triển khai tiếp theo

- Mở rộng chức năng nhập hàng từ nhà cung cấp
- Thêm tính năng cảnh báo email/SMS khi tồn kho thấp
- Tích hợp quét mã vạch bằng camera hoặc thiết bị đầu cuối POS
- Phát triển giao diện web quản trị để quản lý từ xa
- Thêm báo cáo lợi nhuận theo từng mặt hàng, mùa vụ và khu vực bán

---

## 15. Tài liệu và nguồn tham khảo

- Microsoft ASP.NET Core Documentation
- Entity Framework Core Documentation
- SQL Server Transaction Management
- Design Patterns for Enterprise Applications
- Retail Inventory Management Best Practices
