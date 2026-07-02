# 🛒 DoGiaDung — Production-Ready Improvement Plan

> **Status**: Chuyển đổi từ đồ án sinh viên → **Production cho khách hàng thật tại Tây Ban Nha**
> **Khách hàng**: Doanh nghiệp Tây Ban Nha, bán nội địa, 50-200 sản phẩm, ~100-500 visits/ngày
> **Thị trường**: 🇪🇸 Tây Ban Nha (EU) — Người dùng cuối là người Tây Ban Nha
> **Team phát triển**: Dương Quốc Huy, Lương Đình Thông, Lâm Trường Phát (tại Việt Nam)
> **Ngày cập nhật**: 2026-07-02
> **Ngôn ngữ**: 🇪🇸 Español (default) | 🇬🇧 English | 🇻🇳 Tiếng Việt (Admin)
> **Tiền tệ**: EUR (€) | **Lộ trình**: Migrate .NET 10 → Security → Production → i18n → Launch (~4 tháng)

---

## 📊 1. Tổng Quan Dự Án

### 1.1 Hiện trạng

```
ThuongMaiDienTu/
├── Admin/DemoDB2/           # Dashboard quản trị (ASP.NET MVC 5 / .NET Framework 4.7.2)
│   ├── DemoDB2.sln
│   ├── DemoDB2/             # 10 Controllers, 16 Models (EF6 EDMX), 44 Views
│   └── AdminCore/           # .NET 10 proxy (SystemWebAdapters + YARP) — ĐANG DỞ
├── User/DoGiaDung/          # Website khách hàng (ASP.NET MVC 5 / .NET Framework 4.7.2)
│   ├── DoGiaDung.sln
│   ├── DoGiaDung/           # 6 Controllers, 18 Models (EF6 EDMX), 36 Views
│   └── UserCore/            # .NET 10 proxy (SystemWebAdapters + YARP) — ĐANG DỞ
└── Database/                # SQL Server .mdf/.ldf + ChartJS queries
```

| Tính năng | User | Admin | Production-ready? |
|-----------|------|-------|-------------------|
| Đăng ký / Đăng nhập | ✅ | ✅ | ❌ Plain text password |
| Quên / Reset mật khẩu | ✅ | ❌ | ❌ Không rate limit |
| Duyệt sản phẩm theo catalog/tag | ✅ | - | ⚠️ Thiếu cache |
| Tìm kiếm sản phẩm | ✅ | ✅ | ⚠️ Không phân trang Admin |
| Giỏ hàng + Checkout | ✅ | - | ❌ Thiếu DB transaction |
| Thanh toán Stripe | ❌ Chưa có | - | ❌ Cần tích hợp mới |
| Thanh toán PayPal | ✅ | - | ❌ Sandbox only |
| Lịch sử đơn hàng | ✅ | ✅ | ⚠️ OK |
| CRUD Sản phẩm/Catalog/Tin tức/Slider | - | ✅ | ❌ Hard delete |
| Quản lý người dùng | - | ✅ | ❌ Hard delete |
| Đa ngôn ngữ | ❌ | ❌ | ❌ Chưa có |

### 1.2 Gap Analysis: Hiện tại vs Production (Tây Ban Nha)

| Tiêu chí | Hiện tại | Production yêu cầu (EU/ES) | Gap |
|----------|----------|---------------------------|-----|
| **Framework** | .NET Framework 4.7.2 | .NET 10 | 🔴 Phải migrate |
| **ORM** | EF6 EDMX | EF Core | 🔴 Phải migrate |
| **Kiến trúc** | Controller → DbContext trực tiếp | Clean Architecture (Domain/App/Infra/Web) | 🔴 Phải refactor |
| **Password** | Plain text | BCrypt hash | 🔴 Bảo mật |
| **Auth** | Session thủ công | ASP.NET Core Cookie Auth | 🔴 Phải thay |
| **Tiền tệ** | VND (₫) | **EUR (€)** — hỗ trợ multi-currency | 🔴 Phải đổi |
| **Timezone** | UTC+7 (VN) | **Europe/Madrid (CET/CEST)** | 🟠 Phải đổi |
| **Xóa dữ liệu** | Hard delete | Soft delete (DEL_YN) | 🟠 Data integrity |
| **Validation** | Thủ công `if == ""` | FluentValidation | 🟠 Data quality |
| **DB Transaction** | Không có | TransactionScope cho checkout | 🟠 Data integrity |
| **Rate Limiting** | Không có | Login/ForgotPassword/Register | 🟠 Bảo mật |
| **Payment** | VNPay sandbox (VN only) | **Stripe + PayPal** (EU) | 🔴 Phải thay hoàn toàn |
| **Hosting** | Local IIS Express | **Hetzner / Azure West Europe** | 🔴 Phải setup |
| **Backup** | Không có | Daily backup + offsite (EU datacenter) | 🟠 Disaster recovery |
| **Monitoring** | Không có | Serilog + Sentry + Health check | 🟡 Vận hành |
| **SSL/HTTPS** | Không có | Enforce toàn bộ (GDPR yêu cầu) | 🔴 Bảo mật + Pháp lý |
| **GDPR** | Không có | **GDPR + LOPDGDD bắt buộc** | 🔴 Pháp lý EU |
| **VAT** | Không có | **IVA 21%** (VAT Tây Ban Nha) | 🟠 Pháp lý + Tính năng |
| **SEO** | Không có | Google.es, Schema.org tiếng TBN | 🟡 Marketing |
| **Legal** | Không có | Điều khoản, Privacy Policy, Cookie Consent, Factura | 🟡 Pháp lý |
| **i18n** | Tiếng Việt cứng | ES (default) / EN / VI | 🟡 Mở rộng KH |
| **Testing** | Không có | Unit + Integration tests | 🟡 Chất lượng |
| **CI/CD** | Không có | GitHub Actions auto-deploy | 🟡 Vận hành |

---

## 🎯 2. Target Architecture (Production EU)

```
┌──────────────────────────────────────────────┐
│                  INTERNET                     │
│       Cloudflare DNS + CDN (EU region)        │
└────────────────┬─────────────────────────────┘
                 │ HTTPS (TLS 1.3)
┌────────────────▼─────────────────────────────┐
│          Nginx Reverse Proxy                  │
│   (SSL termination, rate limiting, gzip)      │
│   Location: Hetzner (Nuremberg, DE)           │
└────────────────┬─────────────────────────────┘
                 │ HTTP/2
┌────────────────▼─────────────────────────────┐
│       ASP.NET Core (.NET 10) Kestrel          │
│  ┌──────────────────────────────────────┐    │
│  │  DoGiaDung.Web (Razor Pages / MVC)    │    │
│  │  ├─ Areas/Admin (VI/EN/ES)            │    │
│  │  └─ Storefront (ES default)           │    │
│  ├──────────────────────────────────────┤    │
│  │  DoGiaDung.Application               │    │
│  │  ├─ Services (Auth, Product, Order,   │    │
│  │  │   Cart, Email, Payment, Dictionary)│    │
│  │  ├─ DTOs / ViewModels                │    │
│  │  ├─ Validators (FluentValidation)    │    │
│  │  └─ GDPR Compliance Module            │    │
│  ├──────────────────────────────────────┤    │
│  │  DoGiaDung.Domain                    │    │
│  │  ├─ Entities (Product, User, Order…) │    │
│  │  ├─ Value Objects (Money/EUR, VAT)   │    │
│  │  └─ Interfaces                       │    │
│  ├──────────────────────────────────────┤    │
│  │  DoGiaDung.Infrastructure            │    │
│  │  ├─ EF Core (DbContext, Migrations)  │    │
│  │  ├─ Email (SMTP / SendGrid)          │    │
│  │  ├─ Payment (Stripe + PayPal adapters)│   │
│  │  ├─ Cache (MemoryCache / Redis)      │    │
│  │  └─ Logging (Serilog → Sentry)       │    │
│  └──────────────────────────────────────┘    │
└──────────────┬───────────────────────────────┘
               │
      ┌────────┴─────────┐
      │                   │
┌─────▼──────┐   ┌───────▼──────┐
│PostgreSQL/ │   │    Redis     │
│SQL Server  │   │  (Cache +    │
│(Primary)   │   │   Session)   │
│EU Region   │   │              │
└────────────┘   └──────────────┘
```

---

## 📋 3. Lộ Trình Triển Khai (7 Phase)

---

### Phase 1: 🚀 .NET 10 Migration + Clean Architecture

> **Thời gian**: Tuần 1-6 | **Priority**: CRITICAL — Nền tảng cho mọi phase sau
> **Mục tiêu**: App chạy trên .NET 10 với kiến trúc chuẩn, sẵn sàng cho production

#### 1.1 Tạo Solution Structure mới

```
DoGiaDung/                          # Solution root mới
├── DoGiaDung.sln
├── src/
│   ├── DoGiaDung.Domain/           # Entities, Enums, Interfaces
│   │   ├── Entities/
│   │   │   ├── Product.cs
│   │   │   ├── Catalog.cs
│   │   │   ├── User.cs
│   │   │   ├── Admin.cs
│   │   │   ├── Order.cs
│   │   │   ├── Transaction.cs
│   │   │   ├── News.cs
│   │   │   ├── Slide.cs
│   │   │   ├── Tag.cs
│   │   │   ├── Feedback.cs
│   │   │   └── SysDictionary.cs
│   │   ├── Interfaces/
│   │   │   ├── IRepository.cs
│   │   │   ├── ISoftDeletable.cs
│   │   │   └── IAuditable.cs
│   │   └── Domain.csproj
│   ├── DoGiaDung.Application/      # Business logic
│   │   ├── Services/
│   │   │   ├── AuthService.cs
│   │   │   ├── ProductService.cs
│   │   │   ├── OrderService.cs
│   │   │   ├── CartService.cs
│   │   │   ├── EmailService.cs
│   │   │   ├── PaymentService.cs
│   │   │   └── DictionaryService.cs
│   │   ├── DTOs/
│   │   ├── Validators/
│   │   └── Application.csproj
│   ├── DoGiaDung.Infrastructure/   # Data access, external services
│   │   ├── Data/
│   │   │   ├── AppDbContext.cs
│   │   │   └── Configurations/     # EF Core Fluent API configs
│   │   ├── Repositories/
│   │   │   └── EfRepository.cs
│   │   ├── Email/
│   │   │   └── SmtpEmailSender.cs
│   │   ├── Payment/
│   │   │   ├── VnPayAdapter.cs
│   │   │   └── PayPalAdapter.cs
│   │   └── Infrastructure.csproj
│   └── DoGiaDung.Web/             # ASP.NET Core MVC App
│       ├── Controllers/
│       ├── Areas/Admin/
│       ├── Views/
│       ├── wwwroot/
│       └── Web.csproj
└── tests/
    ├── DoGiaDung.UnitTests/
    └── DoGiaDung.IntegrationTests/
```

#### 1.2 Migrate từng bước

- [ ] **1.2.1** Reverse-engineer DB schema từ SQL Server → tạo Entity classes cho EF Core
  - Dùng `Scaffold-DbContext` hoặc viết tay Code-First entities
  - Thêm cột `DEL_YN`, `CREATED_BY`, `CREATED_DT`, `UPDATED_BY`, `UPDATED_DT` ngay từ đầu
- [ ] **1.2.2** Thiết lập EF Core DbContext + Fluent API configurations
  - Thay thế hoàn toàn EDMX (Entity Framework 6)
  - Composite keys, relationships, indexes
- [ ] **1.2.3** Migrate Controllers → Services
  - Mỗi controller cũ → 1 service class mới
  - Tách business logic khỏi presentation
  - Ví dụ: `UserController.LoginAcc()` → `AuthService.LoginAsync()`
- [ ] **1.2.4** Migrate Views (.cshtml)
  - Copy Razor views sang project mới
  - Cập nhật namespace references
  - Thay `@model` bằng ViewModels/DTOs mới
- [ ] **1.2.5** Chuyển Session auth → ASP.NET Core Cookie Authentication
  ```csharp
  // Program.cs
  builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
      .AddCookie(options => {
          options.LoginPath = "/Admin/Login";
          options.LogoutPath = "/Admin/Logout";
          options.ExpireTimeSpan = TimeSpan.FromHours(8);
      });
  ```
- [ ] **1.2.6** Chuyển config: Web.config → `appsettings.json` + User Secrets
- [ ] **1.2.7** Cấu hình multi-currency + timezone:
  ```csharp
  // Program.cs
  builder.Services.Configure<RequestLocalizationOptions>(options =>
  {
      options.DefaultRequestCulture = new RequestCulture("es-ES");
      options.SupportedCultures = new[] { "es-ES", "en-US", "vi-VN" };
  });
  // Currency: EUR (€) là default
  // Timezone: Europe/Madrid
  ```
- [ ] **1.2.8** Thêm Dependency Injection cho tất cả Services
- [ ] **1.2.9** Xóa bỏ YARP proxy (`AdminCore`/`UserCore`) — không cần nữa
- [ ] **1.2.10** Xóa VNPay hoàn toàn khỏi codebase và Web.config (VNPay chỉ hoạt động tại VN)
- [ ] **1.2.11** Xác minh: chạy song song app cũ (MVC5) và app mới (.NET 10) trên local

#### 1.3 Design Patterns — Giữ lại nhưng đặt đúng chỗ

Các pattern học thuật (Template Method, Strategy, Decorator, Singleton, Facade) được giữ lại để minh họa kiến thức, nhưng:

- Di chuyển từ `Controllers/` → `Application/Patterns/`
- Document mục đích học thuật trong comment
- Không dùng cho production code quan trọng

---

### Phase 2: 🔒 Security Hardening

> **Thời gian**: Tuần 6-8 | **Priority**: CRITICAL — Bảo mật khách hàng là trên hết

- [ ] **2.1** Hash password với BCrypt
  ```csharp
  // AuthService.cs
  public async Task<bool> ValidateLogin(string email, string password)
  {
      var user = await _userRepo.GetByEmailAsync(email);
      if (user == null) return false;
      return BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
  }

  public async Task Register(UserRegisterDto dto)
  {
      var user = new User {
          Email = dto.Email,
          PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
          // ...
      };
  }
  ```
  - **Migration script**: Tạo cột `PasswordHash`, hash tất cả password hiện có, xóa cột `Password` cũ sau 1 tuần

- [ ] **2.2** CSRF Protection — `[ValidateAntiForgeryToken]` trên tất cả POST actions
- [ ] **2.3** Security Headers ( Middleware )
  ```csharp
  // SecurityHeadersMiddleware.cs
  context.Response.Headers.Add("X-Frame-Options", "DENY");
  context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
  context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
  context.Response.Headers.Add("Referrer-Policy", "strict-origin-when-cross-origin");
  context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; ...");
  ```
- [ ] **2.4** HTTPS Enforcement — redirect HTTP → HTTPS, HSTS header
- [ ] **2.5** Input Validation với FluentValidation
  ```csharp
  public class RegisterValidator : AbstractValidator<UserRegisterDto>
  {
      public RegisterValidator()
      {
          RuleFor(x => x.Email).NotEmpty().EmailAddress();
          RuleFor(x => x.Password).NotEmpty().MinimumLength(8);
          RuleFor(x => x.Phone).Matches(@"^0\d{9}$");
          RuleFor(x => x.FullName).NotEmpty().MaximumLength(100);
      }
  }
  ```
- [ ] **2.6** Rate Limiting (built-in .NET 7+)
  ```csharp
  // Program.cs
  builder.Services.AddRateLimiter(options => {
      options.AddFixedWindowLimiter("Login", config => {
          config.PermitLimit = 5;           // 5 lần
          config.Window = TimeSpan.FromMinutes(15); // trong 15 phút
      });
  });
  ```
  Áp dụng cho: `Login`, `Register`, `ForgotPassword`
- [ ] **2.7** reCAPTCHA v3 cho Register, Login, ForgotPassword, Contact
- [ ] **2.8** Secure Cookies: `HttpOnly`, `Secure`, `SameSite=Strict`
- [ ] **2.9** Secrets Management: di chuyển Stripe keys, PayPal keys, Email password, ConnectionString → Azure Key Vault hoặc Environment Variables
- [ ] **2.10** GDPR Compliance (bắt buộc cho EU):
  - Cookie consent banner với opt-in (không auto-accept, không pre-ticked)
  - Ghi log consent của user (thời gian, IP, nội dung đồng ý)
  - Privacy Policy page (`/privacy`) — liệt kê dữ liệu thu thập, mục đích, thời gian lưu, bên thứ 3
  - Right to access: user có thể xem toàn bộ dữ liệu cá nhân của mình
  - Right to be forgotten: nút "Xóa tài khoản" xóa hoàn toàn dữ liệu cá nhân (thực sự xóa, không soft delete)
  - Data encryption at rest (SQL Server TDE hoặc column-level encryption)
  - Data Processing Agreement với Stripe/PayPal/Cloudflare

---

### Phase 3: 🗑️ Soft Delete — Xóa Mềm Toàn Hệ Thống

> **Thời gian**: Tuần 8-9 | **Priority**: HIGH — Data integrity cho production

> **Nguyên tắc**: KHÔNG bao giờ xóa cứng. Mọi thao tác "xóa" chỉ set `DEL_YN = 'Y'`.

#### 3.1 DB Schema

```sql
ALTER TABLE Product      ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE Catalog      ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE [News]       ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE Slide        ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE Tag          ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE [Transaction] ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE [Order]      ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE Feedback     ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE [User]       ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
ALTER TABLE Admin        ADD DEL_YN CHAR(1) DEFAULT 'N' NOT NULL;
-- sysdiagram là bảng hệ thống — không cần soft delete
```

> Các bảng `News`, `Order`, `User`, `Transaction` là reserved SQL keywords — escape bằng `[]`.

#### 3.2 EF Core Global Query Filter

```csharp
// AppDbContext.cs — tự động filter, không cần Where() thủ công
modelBuilder.Entity<Product>().HasQueryFilter(p => p.DEL_YN == "N");
modelBuilder.Entity<Catalog>().HasQueryFilter(c => c.DEL_YN == "N");
modelBuilder.Entity<News>().HasQueryFilter(n => n.DEL_YN == "N");
// ... tất cả entity

// Khi cần bỏ filter (vd: trang Thùng rác của Admin):
var deleted = await _context.Products.IgnoreQueryFilters()
    .Where(p => p.DEL_YN == "Y").ToListAsync();
```

#### 3.3 Interface

```csharp
// Domain/Interfaces/ISoftDeletable.cs
public interface ISoftDeletable
{
    string DEL_YN { get; set; }  // 'N' = active, 'Y' = deleted
}
```

#### 3.4 Quy tắc truy vấn

| Thao tác | Cũ | Mới |
|----------|----|-----|
| **Xóa** | `db.Remove(entity)` | `entity.DEL_YN = 'Y'` |
| **Hiển thị** | `ToList()` | Tự động filter bởi Global Query Filter |
| **Khôi phục** | ❌ | `entity.DEL_YN = 'N'` |

#### 3.5 Cascade Display

```csharp
// Order Detail View — khi PRODUCT đã bị soft delete:
@if (order.Product?.DEL_YN == "Y")
{
    <span class="text-muted">@Lang.Get("MSG_PRODUCT_DELETED")</span>
}
else
{
    <a asp-action="Detail" asp-controller="Product"
       asp-route-id="@order.ProductId">@order.Product.Name</a>
}
```

#### 3.6 Thùng rác + Khôi phục

- [ ] Admin: Mỗi controller có `Restore` action + `Trash` view
- [ ] Admin Layout: Badge hiển thị số item trong thùng rác
- [ ] User side: Tất cả query đều tự động filter `DEL_YN = 'N'` (nhờ Global Query Filter)

---

### Phase 4: 🏭 Production Readiness — Spain/EU

> **Thời gian**: Tuần 9-11 | **Priority**: HIGH — Đưa app lên production EU

#### 4.1 Hosting Setup — EU Datacenter

| Bước | Chi tiết |
|------|----------|
| Mua domain | `.es` hoặc `.com` (khuyến nghị: `dogiadung.es`) |
| Đăng ký VPS | **Hetzner CCX22** (Nuremberg, DE): 2 vCPU, 4GB RAM, 40GB SSD, **~€4/tháng** |
| Cài đặt | Ubuntu 24.04 + .NET 10 Runtime + Nginx + PostgreSQL |
| Cloudflare | Free plan: DNS, SSL, CDN (EU region), DDoS |
| Deploy | Web Deploy hoặc GitHub Actions → tự động deploy |

> **Tại sao Hetzner + PostgreSQL?**
> - Hetzner rẻ nhất EU (~€4/tháng) và latency ~30-40ms đến Madrid
> - PostgreSQL miễn phí (không cần license SQL Server) — tiết kiệm €100+/tháng
> - Nếu cần SQL Server: Azure SQL (West Europe) từ ~$5/tháng basic tier
>
> Xem chi tiết ở **Section 5: Hosting Recommendation**

> **Nếu khách hàng muốn hosting tại Tây Ban Nha**: Stackscale (Madrid) — đắt hơn (~€20-30/tháng) nhưng latency siêu thấp, data sovereignty TBN.

- [ ] **4.1.1** Mua domain `.es` (qua DonDominio, OVH, hoặc Namecheap)
- [ ] **4.1.2** Đăng ký Hetzner Cloud + tạo VPS
- [ ] **4.1.3** Cài Ubuntu 24.04 + .NET 10 Runtime + Nginx + PostgreSQL 16
- [ ] **4.1.4** Cấu hình Nginx reverse proxy → Kestrel
- [ ] **4.1.5** Setup PostgreSQL: tạo database, user, migration
- [ ] **4.1.6** Cấu hình Cloudflare: DNS → VPS IP, SSL Full (strict), CDN EU
- [ ] **4.1.7** Deploy lần đầu + verify

#### 4.2 Payment Production — Stripe (EU)

**Khuyến nghị: Stripe** — cổng thanh toán phổ biến nhất EU:
- Hỗ trợ thẻ tín dụng (Visa/Mastercard) + SEPA Direct Debit
- Apple Pay + Google Pay
- Thanh toán bằng EUR (€)
- SDK chính thức cho .NET: `Stripe.net`
- Settle về tài khoản ngân hàng TBN (IBAN ES)

> **Backup option: Redsys** — nếu khách hàng có merchant account với ngân hàng TBN (CaixaBank, BBVA, Santander). Stripe dễ tích hợp hơn, không cần merchant account.

- [ ] **4.2.1** Đăng ký Stripe account (https://stripe.com) — chọn Spain làm country
- [ ] **4.2.2** Lấy `PublishableKey` + `SecretKey` từ Stripe Dashboard
- [ ] **4.2.3** Cài NuGet package: `Stripe.net`
- [ ] **4.2.4** Implement Stripe Checkout (hosted page — đơn giản, PCI compliant):
  ```csharp
  // PaymentService.cs
  public async Task<string> CreateStripeCheckoutSession(Order order)
  {
      var options = new SessionCreateOptions
      {
          PaymentMethodTypes = new List<string> { "card", "sepa_debit" },
          LineItems = order.Items.Select(item => new SessionLineItemOptions
          {
              PriceData = new SessionLineItemPriceDataOptions
              {
                  Currency = "eur",
                  UnitAmount = (long)(item.UnitPrice * 100), // cents
                  ProductData = new SessionLineItemPriceDataProductDataOptions
                  {
                      Name = item.ProductName,
                  },
              },
              Quantity = item.Quantity,
          }).ToList(),
          Mode = "payment",
          SuccessUrl = "https://dogiadung.es/checkout/success?session_id={CHECKOUT_SESSION_ID}",
          CancelUrl = "https://dogiadung.es/cart",
          CustomerEmail = order.CustomerEmail,
      };
      var service = new SessionService();
      var session = await service.CreateAsync(options);
      return session.Url; // Redirect user to Stripe
  }
  ```
- [ ] **4.2.5** Implement Stripe Webhook để nhận payment confirmation:
  ```csharp
  [HttpPost("webhook/stripe")]
  public async Task<IActionResult> StripeWebhook()
  {
      var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
      var stripeEvent = EventUtility.ConstructEvent(json,
          Request.Headers["Stripe-Signature"], _webhookSecret);
      if (stripeEvent.Type == Events.CheckoutSessionCompleted)
      {
          var session = stripeEvent.Data.Object as Session;
          await _orderService.ConfirmPaymentAsync(session.Id);
      }
      return Ok();
  }
  ```
- [ ] **4.2.6** Giữ **PayPal** làm phương thức thanh toán phụ (vẫn hoạt động tốt ở EU)
- [ ] **4.2.7** Test thanh toán thật với Stripe test mode (dùng thẻ test `4242 4242 4242 4242`)
- [ ] **4.2.8** Switch sang Stripe live mode trước go-live

#### 4.3 EU VAT Handling (IVA)

- [ ] **4.3.1** Cấu hình VAT rates TBN:
  ```csharp
  public static class VatRates
  {
      public const decimal General = 0.21m;     // 21% — hầu hết sản phẩm
      public const decimal Reduced = 0.10m;      // 10% — thực phẩm, vận chuyển
      public const decimal SuperReduced = 0.04m; // 4% — bánh mì, sữa, sách, thuốc
  }
  ```
- [ ] **4.3.2** Mỗi Product có `VatRate` property (mặc định 21%)
- [ ] **4.3.3** Hiển thị giá đã bao gồm VAT (quy định EU):
  ```html
  <!-- Price display: -->
  <span class="price">@product.PriceIncludingVat.ToString("C2", new CultureInfo("es-ES"))</span>
  <small class="vat-info">IVA incluido</small>
  ```
- [ ] **4.3.4** Hóa đơn (Factura) VAT compliant: số hóa đơn, NIF/CIF, base amount, VAT rate, VAT amount, total
- [ ] **4.3.5** PDF invoice generation (dùng `IronPDF`, `DinkToPdf`, hoặc `QuestPDF`)

#### 4.4 Backup & Disaster Recovery (EU)

```
BACKUP STRATEGY:
├── PostgreSQL Backup (pg_dump)
│   ├── Full backup: Daily @ 2:00 AM CET (giữ 7 ngày)
│   └── WAL Archiving: Continuous (point-in-time recovery)
├── File Backup (uploaded images)
│   └── Cloudflare R2 (EU region): sync mỗi giờ
└── Offsite Backup
    └── Weekly: copy lên Hetzner Storage Box (€3/tháng cho 1TB)
```

- [ ] **4.4.1** Cấu hình `pg_dump` cron job
- [ ] **4.4.2** Cấu hình WAL archiving cho point-in-time recovery
- [ ] **4.4.3** Upload file backup lên Cloudflare R2 (€0.015/GB — rẻ hơn S3)
- [ ] **4.4.4** **Test restore 1 lần/tháng**

#### 4.5 Monitoring & Alerting (EU timezone)

| Công cụ | Mục đích | Chi phí |
|---------|----------|---------|
| **Serilog** | Structured logging → file + console | Free |
| **Sentry** | Error tracking (EU datacenter available) | Free tier (5K events/tháng) |
| **UptimeRobot** | Ping `/health` mỗi 5 phút, alert Telegram/SMS | Free (50 monitors) |
| **Health Check** | DB + Stripe API + Email health | Built-in .NET |

#### 4.6 SEO — Google.es

- [ ] **4.6.1** Dynamic `sitemap.xml` (Spanish URLs: `/productos/nombre-producto`)
- [ ] **4.6.2** `robots.txt`
- [ ] **4.6.3** Meta tags tiếng Tây Ban Nha: `<title>`, `<meta description>`, `og:title`, `og:image`
- [ ] **4.6.4** Schema.org JSON-LD tiếng Tây Ban Nha:
  - `Organization` (tienda), `Product` (producto), `BreadcrumbList`
- [ ] **4.6.5** Google Search Console (target Spain) + Google Analytics 4
- [ ] **4.6.6** URL rewrite thân thiện: `/Product/Detail/123` → `/productos/nombre-producto`
- [ ] **4.6.7** Custom 404 page + 301 redirect
- [ ] **4.6.8** Hreflang tags cho đa ngôn ngữ: `<link rel="alternate" hreflang="es" href="..." />`

#### 4.7 Legal — GDPR + LOPDGDD (Spain)

> **GDPR áp dụng cho mọi website phục vụ người dùng EU. Mức phạt: lên đến €20M hoặc 4% doanh thu toàn cầu.**
> **LOPDGDD (Ley Orgánica de Protección de Datos y Garantía de Derechos Digitales)**: luật bảo vệ dữ liệu riêng của Tây Ban Nha, bổ sung cho GDPR.

- [ ] **4.7.1** Aviso Legal (Legal Notice) — bắt buộc ở TBN: tên công ty, NIF/CIF, địa chỉ, email, điện thoại
- [ ] **4.7.2** Política de Privacidad (Privacy Policy) — GDPR compliant
- [ ] **4.7.3** Política de Cookies (Cookie Policy) + banner với opt-in
- [ ] **4.7.4** Términos y Condiciones (Terms & Conditions)
- [ ] **4.7.5** Política de Devoluciones (Returns Policy)
- [ ] **4.7.6** Cookie consent implementation:
  ```csharp
  // GdprConsentService.cs
  public enum ConsentCategory { Necessary, Analytics, Marketing }
  
  public async Task LogConsent(int userId, ConsentCategory category, bool granted, string ip)
  {
      // Lưu consent log để chứng minh với cơ quan chức năng nếu bị audit
  }
  ```
- [ ] **4.7.7** Right to be forgotten: tính năng xóa tài khoản + xóa toàn bộ PII (thực sự xóa, không soft delete)
- [ ] **4.7.8** Data export: user có thể download toàn bộ dữ liệu cá nhân (JSON/CSV)

> **Khuyến cáo**: Thuê luật sư chuyên về GDPR/LOPDGDD để review legal docs. Không nên tự viết — sai sót có thể bị phạt rất nặng.

---

### Phase 5: 🌐 Đa Ngôn Ngữ — i18n (ES default / EN / VI)

> **Thời gian**: Tuần 11-14 | **Priority**: MEDIUM
> **Default language**: 🇪🇸 **Español (ES)** — khách hàng cuối là người Tây Ban Nha
> **Secondary**: 🇬🇧 English — ngôn ngữ quốc tế, dự phòng
> **Tertiary**: 🇻🇳 Tiếng Việt — cho team phát triển/admin VN

#### 5.1 Bảng Từ Điển `SysDictionary`

```sql
CREATE TABLE SysDictionary (
    DicId        INT IDENTITY(1,1) PRIMARY KEY,
    LngTp        VARCHAR(10)  NOT NULL,       -- 'EN', 'VI', 'ES'
    ColCd        VARCHAR(100) NOT NULL,       -- Mã từ khóa (vd: 'NAV_HOME')
    ColCdTp      VARCHAR(50)  NOT NULL DEFAULT '0', -- Mã phụ
    SortSeq      INT DEFAULT 1,
    ColCdTpNm    NVARCHAR(500) NOT NULL,      -- Văn bản đã dịch
    RegDt        VARCHAR(14),                 -- Ngày tạo
    ClsDt        VARCHAR(14),                 -- Ngày đóng
    WorkMn       VARCHAR(50),                 -- Người sửa
    WorkDt       VARCHAR(14),                 -- Ngày sửa
    WorkIp       VARCHAR(50),
    CnfmSeq      VARCHAR(50),
    CnfmUser     VARCHAR(50),
    CnfmDt       VARCHAR(14),
    CnfmIp       VARCHAR(50),
    VsdTp        VARCHAR(10),
    Note         NVARCHAR(500)
);

CREATE INDEX IX_Dic_Lng_Col ON SysDictionary(LngTp, ColCd, ColCdTp);
```

#### 5.2 Quy ước Mã Từ Điển

| Prefix | Phạm vi | Ví dụ |
|--------|---------|-------|
| `NAV_*` | Menu & điều hướng | `NAV_HOME`, `NAV_PRODUCT`, `NAV_CONTACT` |
| `BTN_*` | Nút bấm | `BTN_ADD_TO_CART`, `BTN_CHECKOUT`, `BTN_LOGIN` |
| `LBL_*` | Nhãn / Label | `LBL_PRICE`, `LBL_QUANTITY`, `LBL_EMAIL` |
| `MSG_*` | Thông báo | `MSG_LOGIN_ERR`, `MSG_ORDER_SUCCESS` |
| `TTL_*` | Tiêu đề trang | `TTL_HOME`, `TTL_PRODUCT_DETAIL` |
| `TBL_*` | Cột bảng | `TBL_PRODUCT_NAME`, `TBL_ORDER_DATE` |
| `PLH_*` | Placeholder | `PLH_SEARCH`, `PLH_EMAIL` |
| `VAL_*` | Validation | `VAL_REQUIRED`, `VAL_EMAIL_INVALID` |
| `FT_*`  | Footer | `FT_COPYRIGHT`, `FT_ADDRESS` |
| `MSS*`  | Trạng thái hệ thống | `MSS1`, `MSS2`, `MSS3`, `MSS_N1` |

> **Trạng thái đơn hàng (MSS*):**
> 
> | COL_CD | EN | VI | ES |
> |--------|-----|-----|-----|
> | `MSS1` | `Processing` | `Đang xử lý` | `En proceso` |
> | `MSS2` | `Confirmed` | `Đã xác nhận` | `Confirmado` |
> | `MSS3` | `Paid` | `Đã thanh toán` | `Pagado` |
> | `MSS_N1` | `Cancelled` | `Đã hủy` | `Cancelado` |

#### 5.3 Dữ liệu mẫu (ES là ngôn ngữ gốc)

```sql
-- Español (ES) — DEFAULT
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES
('ES', 'NAV_HOME',     '0', 1, 'Inicio'),
('ES', 'NAV_PRODUCT',  '0', 1, 'Productos'),
('ES', 'NAV_CONTACT',  '0', 1, 'Contacto'),
('ES', 'NAV_ABOUT',    '0', 1, 'Sobre Nosotros'),
('ES', 'NAV_LOGIN',    '0', 1, 'Iniciar Sesión'),
('ES', 'NAV_REGISTER', '0', 1, 'Registrarse'),
('ES', 'NAV_LOGOUT',   '0', 1, 'Cerrar Sesión'),
('ES', 'NAV_CART',     '0', 1, 'Carrito'),
('ES', 'BTN_ADD_TO_CART',  '0', 1, 'Añadir al Carrito'),
('ES', 'BTN_CHECKOUT',     '0', 1, 'Pagar'),
('ES', 'BTN_SUBMIT',       '0', 1, 'Enviar'),
('ES', 'BTN_CANCEL',       '0', 1, 'Cancelar'),
('ES', 'BTN_SEARCH',       '0', 1, 'Buscar'),
('ES', 'BTN_SAVE',         '0', 1, 'Guardar'),
('ES', 'MSG_LOGIN_ERR',    '0', 1, 'Correo o contraseña inválidos.'),
('ES', 'MSG_REGISTER_ERR', '0', 1, 'Registro fallido. Inténtelo de nuevo.'),
('ES', 'MSG_ORDER_SUCCESS','0', 1, '¡Su pedido ha sido realizado con éxito!'),
('ES', 'MSG_EMPTY_CART',   '0', 1, 'Su carrito está vacío.'),
('ES', 'MSG_RESET_PASS',   '0', 1, 'Se ha enviado un correo para restablecer la contraseña.'),
('ES', 'MSS1', '0', 1, 'En proceso'),
('ES', 'MSS2', '0', 1, 'Confirmado'),
('ES', 'MSS3', '0', 1, 'Pagado'),
('ES', 'MSS_N1', '0', 1, 'Cancelado');

-- English (EN)
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES
('EN', 'NAV_HOME',     '0', 1, 'Home'),
('EN', 'NAV_PRODUCT',  '0', 1, 'Products'),
('EN', 'NAV_CONTACT',  '0', 1, 'Contact'),
('EN', 'NAV_ABOUT',    '0', 1, 'About Us'),
('EN', 'NAV_LOGIN',    '0', 1, 'Login'),
('EN', 'NAV_REGISTER', '0', 1, 'Register'),
('EN', 'NAV_LOGOUT',   '0', 1, 'Logout'),
('EN', 'NAV_CART',     '0', 1, 'Shopping Cart'),
('EN', 'BTN_ADD_TO_CART',  '0', 1, 'Add to Cart'),
('EN', 'BTN_CHECKOUT',     '0', 1, 'Checkout'),
('EN', 'BTN_SUBMIT',       '0', 1, 'Submit'),
('EN', 'BTN_CANCEL',       '0', 1, 'Cancel'),
('EN', 'BTN_SEARCH',       '0', 1, 'Search'),
('EN', 'BTN_SAVE',         '0', 1, 'Save'),
('EN', 'MSG_LOGIN_ERR',    '0', 1, 'Invalid email or password.'),
('EN', 'MSG_REGISTER_ERR', '0', 1, 'Registration failed. Please try again.'),
('EN', 'MSG_ORDER_SUCCESS','0', 1, 'Your order has been placed successfully!'),
('EN', 'MSG_EMPTY_CART',   '0', 1, 'Your shopping cart is empty.'),
('EN', 'MSG_RESET_PASS',   '0', 1, 'Password reset email has been sent.'),
('EN', 'MSS1', '0', 1, 'Processing'),
('EN', 'MSS2', '0', 1, 'Confirmed'),
('EN', 'MSS3', '0', 1, 'Paid'),
('EN', 'MSS_N1', '0', 1, 'Cancelled');

-- Tiếng Việt (VI) — cho Admin team
INSERT INTO SysDictionary (LngTp, ColCd, ColCdTp, SortSeq, ColCdTpNm) VALUES
('VI', 'NAV_HOME',     '0', 1, 'Trang chủ'),
('VI', 'NAV_PRODUCT',  '0', 1, 'Sản phẩm'),
('VI', 'NAV_CONTACT',  '0', 1, 'Liên hệ'),
('VI', 'NAV_ABOUT',    '0', 1, 'Giới thiệu'),
('VI', 'NAV_LOGIN',    '0', 1, 'Đăng nhập'),
('VI', 'NAV_REGISTER', '0', 1, 'Đăng ký'),
('VI', 'NAV_LOGOUT',   '0', 1, 'Đăng xuất'),
('VI', 'NAV_CART',     '0', 1, 'Giỏ hàng'),
('VI', 'BTN_ADD_TO_CART',  '0', 1, 'Thêm vào giỏ'),
('VI', 'BTN_CHECKOUT',     '0', 1, 'Thanh toán'),
('VI', 'BTN_SUBMIT',       '0', 1, 'Gửi'),
('VI', 'BTN_CANCEL',       '0', 1, 'Hủy'),
('VI', 'BTN_SEARCH',       '0', 1, 'Tìm kiếm'),
('VI', 'BTN_SAVE',         '0', 1, 'Lưu'),
('VI', 'MSG_LOGIN_ERR',    '0', 1, 'Sai thông tin đăng nhập.'),
('VI', 'MSG_REGISTER_ERR', '0', 1, 'Đăng ký thất bại. Vui lòng thử lại.'),
('VI', 'MSG_ORDER_SUCCESS','0', 1, 'Đơn hàng của bạn đã được đặt thành công!'),
('VI', 'MSG_EMPTY_CART',   '0', 1, 'Giỏ hàng của bạn đang trống.'),
('VI', 'MSG_RESET_PASS',   '0', 1, 'Email đặt lại mật khẩu đã được gửi.'),
('VI', 'MSS1', '0', 1, 'Đang xử lý'),
('VI', 'MSS2', '0', 1, 'Đã xác nhận'),
('VI', 'MSS3', '0', 1, 'Đã thanh toán'),
('VI', 'MSS_N1', '0', 1, 'Đã hủy');
```

#### 5.4 Kiến trúc Code

- [ ] **5.4.1** `DictionaryService`:
  ```csharp
  public interface IDictionaryService
  {
      string Get(string colCd, string colCdTp = "0");
      Dictionary<string, string> GetGroup(string prefix);
      List<SysDictionary> GetAllTranslations(string colCd);
      string CurrentLanguage { get; }
      void SetLanguage(string lang);
  }
  ```
- [ ] **5.4.2** Lưu ngôn ngữ vào **Cookie** (không Session — tương thích với stateless .NET Core):
  ```csharp
  // Set
  Response.Cookies.Append("lang", "ES", new CookieOptions { // ES = default
      Expires = DateTimeOffset.UtcNow.AddYears(1),
      HttpOnly = true,
      Secure = true
  });
  // Get — fallback ES (khách hàng TBN)
  string lang = Request.Cookies["lang"] ?? "ES";
  ```
- [ ] **5.4.3** HTML Helper: `@Lang.Get("NAV_HOME")` → tự động theo ngôn ngữ cookie
- [ ] **5.4.4** Language Switcher trong Layout (ES = default, hiển thị đầu tiên):
  ```html
  <select id="langSwitcher" onchange="switchLang(this.value)">
      <option value="ES">🇪🇸 Español</option>
      <option value="EN">🇬🇧 English</option>
      <option value="VI">🇻🇳 Tiếng Việt</option>
  </select>
  ```
- [ ] **5.4.5** Admin page quản lý từ điển (edit online, export/import Excel)
- [ ] **5.4.6** Data Annotation validation messages qua `ErrorMessageResourceType`
- [ ] **5.4.7** Format tiền tệ theo ngôn ngữ: `1.000,00 €` (ES) | `$1,000.00` (EN) | `1.000.000₫` (VI)
- [ ] **5.4.8** MemoryCache cho dictionary (TTL 30 phút, invalidate khi admin sửa)
- [ ] **5.4.9** (Optional) `ProductTranslation` table cho tên/mô tả sản phẩm đa ngôn ngữ

#### 5.5 Lộ trình dịch (ES trước, sau đó EN và VI)

| Bước | Phạm vi | Keys | Công sức |
|------|---------|------|----------|
| 1 | DB + Backend (DictionaryService, cache, helper) | - | 2-3 ngày |
| 2 | Shared Layout (menu, footer, language switcher) ES → EN → VI | ~30 keys × 3 | 2 ngày |
| 3 | Auth pages (Login, Register, ForgotPassword, ResetPassword) | ~30 keys × 3 | 2 ngày |
| 4 | User pages (Home, Product, Cart, Checkout, Contact) — tiếng TBN | ~60 keys × 3 | 3 ngày |
| 5 | Admin pages (Dashboard, CRUD, tables) — cả 3 ngôn ngữ | ~50 keys × 3 | 3 ngày |
| 6 | Validation/Error messages | ~25 keys × 3 | 1 ngày |
| 7 | Email templates (3 templates × 3 ngôn ngữ) | - | 2 ngày |
| 8 | Admin Dictionary UI | - | 2 ngày |
| 9 | **Cần người bản xứ TBN review** toàn bộ text tiếng Tây Ban Nha | - | 1-2 ngày |
| **Tổng** | | **~200-250 keys × 3 ngôn ngữ = ~600-750 records** | **~15-17 ngày** |

> **Quan trọng**: Tiếng Tây Ban Nha là ngôn ngữ chính của khách hàng cuối. Cần **native Spanish speaker** review tất cả text trước khi go-live. Không dùng Google Translate cho production!

---

### Phase 6: ✅ Pre-Launch Checklist

> **Thời gian**: Tuần 14-15 | **Priority**: CRITICAL — Cửa cuối cùng trước khi ra production

#### 6.1 Security + GDPR Audit

- [ ] Kiểm tra OWASP Top 10: Injection, Broken Auth, Sensitive Data Exposure, XXE, Broken Access Control, Security Misconfiguration, XSS, Insecure Deserialization, Using Known Vulnerable Components, Insufficient Logging
- [ ] Scan secrets trong git history (dùng `truffleHog` hoặc `git-secrets`)
- [ ] Xác minh không còn password/test key nào trong source code
- [ ] Kiểm tra CSP header không quá restrictive (test tất cả pages)
- [ ] SQL injection test (dù EF Core đã parameterize)
- [ ] **GDPR Compliance Audit**:
  - Cookie consent: banner hiển thị + opt-in hoạt động + consent được log
  - Privacy Policy đầy đủ và chính xác
  - Right to access: user xem được dữ liệu cá nhân
  - Right to be forgotten: user xóa được tài khoản
  - Data encryption: kiểm tra dữ liệu cá nhân được mã hóa
  - Third-party data processing: Stripe/PayPal/Cloudflare DPA
- [ ] **LOPDGDD** (luật TBN): Aviso Legal, thông tin công ty đầy đủ

#### 6.2 Performance

- [ ] Load test: 100 concurrent users (dùng `k6` hoặc `Apache Bench`)
- [ ] Page load < 3s với connection 3G
- [ ] Image optimization (WebP format, lazy loading)
- [ ] CSS/JS minification + bundling
- [ ] Browser caching headers cho static files

#### 6.3 Browser & Device

- [ ] Chrome, Firefox, Safari, Edge — tất cả tính năng hoạt động
- [ ] Mobile (iPhone, Android) — responsive, touch-friendly
- [ ] Tablet — layout không bể

#### 6.4 Payment Flow

- [ ] Test Stripe test mode: checkout → redirect → webhook → confirm order
- [ ] Test Stripe live mode: thanh toán thật €1
- [ ] Test PayPal sandbox
- [ ] Test SEPA Direct Debit (nếu Stripe hỗ trợ)
- [ ] Test hủy đơn hàng + hoàn tiền (Stripe refund)

#### 6.5 Email

- [ ] Test gửi mail đơn hàng (Gmail/Yahoo/Outlook)
- [ ] Test gửi mail reset password
- [ ] Kiểm tra email không vào spam (SPF, DKIM, DMARC records)
- [ ] Email template hiển thị đúng trên mobile

#### 6.6 Infrastructure

- [ ] SSL certificate active (Cloudflare hoặc Let's Encrypt)
- [ ] DNS propagated đầy đủ (cả `www` và apex domain)
- [ ] Backup: chạy thử restore 1 lần
- [ ] Health check endpoint hoạt động
- [ ] UptimeRobot đã được cấu hình

#### 6.7 SEO & Analytics

- [ ] Sitemap.xml submitted lên Google Search Console
- [ ] Robots.txt không block các trang quan trọng
- [ ] GA4 tracking code active
- [ ] Meta tags đầy đủ trên tất cả pages

#### 6.8 Content

- [ ] Không còn text mẫu / lorem ipsum
- [ ] Không còn "Your application description page"
- [ ] Tất cả text đã được dịch sang tiếng Tây Ban Nha
- [ ] **Người bản xứ Tây Ban Nha review** tất cả content (quan trọng!)
- [ ] Thông tin liên hệ chính xác (địa chỉ TBN, NIF/CIF, email, điện thoại)
- [ ] Giá sản phẩm hiển thị EUR + bao gồm IVA
- [ ] Favicon + og:image
- [ ] URL thân thiện tiếng Tây Ban Nha: `/productos/nombre-producto`

---

### Phase 7: 🚢 Go-Live & Post-Launch

> **Thời gian**: Tuần 15-16 | **Priority**: CRITICAL — Giây phút quyết định

#### 7.1 Go-Live Playbook (CET timezone)

```
NGÀY GO-LIVE (Day 0) — Giờ CET (Europe/Madrid):
├── 02:00  Backup database production (lần cuối trước deploy)
├── 03:00  Chạy EF Core migrations lên production DB
├── 04:00  Deploy application lên VPS Hetzner
├── 04:30  Warm-up: visit tất cả key pages
├── 05:00  Verify: đăng nhập, xem sản phẩm, đặt hàng thử với Stripe test
├── 05:30  Switch Cloudflare DNS sang origin production
├── 06:00  LIVE! 🚀 (8:00 AM ở TBN — giờ thức dậy của khách hàng)
├── 06:30  Monitor error logs liên tục
└── 18:00  Daily review: errors, performance, orders
```

#### 7.2 7 Ngày Đầu Sau Launch

| Ngày | Checklist |
|------|-----------|
| **Day 1** | Monitor error logs mỗi 2h. Check Stripe webhook hoạt động. Verify email gửi được. |
| **Day 2** | Check Google.es Search Console indexing. Review GA4 data. Backup file integrity check. |
| **Day 3** | Performance review (page load time). Tối ưu nếu cần. Check mobile UX. |
| **Day 4** | Customer feedback review. Hotfix nếu có bug. Retest payment flow (Stripe + PayPal). |
| **Day 5** | Security log review. Check rate limiting + GDPR consent logging. Backup restore test. |
| **Day 6** | SEO: check crawl errors. Fix broken links. Content update nếu cần. |
| **Day 7** | Week 1 retrospective. Update bugs list. Plan next sprint. |

#### 7.3 Ongoing (Sau tuần đầu)

- Weekly: backup verify, error log review, uptime report
- Monthly: security patches, backup restore test, performance audit
- Quarterly: new features, major updates

---

## 🖥️ 5. Hosting Recommendation — EU/Spain

### So sánh các option cho thị trường Tây Ban Nha

| Tiêu chí | **Hetzner CCX22** | **Azure App Service B1** | **Stackscale (Madrid)** | **OVHcloud (France)** |
|----------|-------------------|--------------------------|-------------------------|-----------------------|
| **Location** | Nuremberg, DE | West Europe (NL) | Madrid, ES 🇪🇸 | Gravelines, FR |
| **Latency → Madrid** | ~30-40ms | ~20-30ms | ~3-5ms | ~15-20ms |
| **Chi phí/tháng** | **~€4** | ~$13 (€12) | ~€20-30 | ~€5-8 |
| **RAM** | 4GB | 1.75GB | 2-4GB | 2-4GB |
| **Storage** | 40GB NVMe | 10GB | 50GB SSD | 40GB SSD |
| **OS** | Linux/Windows | Managed | Linux/Windows | Linux/Windows |
| **Managed** | ❌ Tự quản trị | ✅ Fully managed | ❌ Tự quản trị | ❌ Tự quản trị |
| **Database** | PostgreSQL (free) | Azure SQL ($5+) | PostgreSQL (free) | PostgreSQL (free) |
| **.NET 10** | ✅ Cài runtime | ✅ Native | ✅ Cài runtime | ✅ Cài runtime |
| **GDPR** | ✅ EU datacenter | ✅ EU datacenter | ✅ Spanish DC | ✅ EU datacenter |

### Khuyến nghị 1: Hetzner CX22 + Cloudflare Free (tiết kiệm nhất)

```
┌────────────┐     ┌──────────────────┐     ┌─────────────────┐
│ Cloudflare │────▶│ Hetzner (DE)     │────▶│ PostgreSQL      │
│ (CDN EU +  │     │ Ubuntu + Kestrel │     │ (local)         │
│  SSL Free) │     │ 2 vCPU/4GB/40GB  │     │                 │
└────────────┘     └──────────────────┘     └─────────────────┘
                         €4/tháng
```

**Ưu điểm**: Rẻ nhất EU, hiệu năng tốt, PostgreSQL miễn phí license
**Nhược điểm**: Tự quản trị server Linux, cần biết Ubuntu + Nginx

### Khuyến nghị 2: Azure App Service B1 + Azure SQL (nếu cần managed)

**Ưu điểm**: Không phải quản lý server, auto-scale, CI/CD sẵn
**Nhược điểm**: Đắt hơn (~€17/tháng), cần Azure SQL license

### Khuyến nghị 3: Stackscale Madrid (nếu cần data sovereignty TBN)

**Ưu điểm**: Hosting tại Tây Ban Nha, latency cực thấp, data nằm hoàn toàn trong TBN
**Nhược điểm**: Đắt nhất (~€20-30/tháng)

### Chi phí ước tính hàng tháng (Hetzner option)

| Khoản mục | Chi phí |
|-----------|---------|
| VPS Hetzner CX22 (2 vCPU/4GB/40GB) | **€4.00** |
| Domain .es (qua DonDominio/Namecheap) | ~€1.00/tháng (~€12/năm) |
| Cloudflare Free | €0 |
| PostgreSQL | €0 (cài trên VPS) |
| Stripe phí giao dịch | 1.4% + €0.25 cho thẻ EU |
| PayPal phí giao dịch | ~2.9% + €0.35 |
| UptimeRobot Free | €0 |
| Sentry Free | €0 |
| Hetzner Storage Box (backup) | €3.00 (1TB) |
| **Tổng cố định** | **~€8.00/tháng** |

### Chi phí ước tính (Azure option)

| Khoản mục | Chi phí |
|-----------|---------|
| Azure App Service B1 (West Europe) | ~€12.00 |
| Azure SQL Database (Basic, 2GB) | ~€5.00 |
| Domain .es | ~€1.00 |
| Công cụ khác (Cloudflare, Sentry…) | €0 |
| **Tổng cố định** | **~€18.00/tháng** |

> **Khuyến nghị cuối cùng**: Bắt đầu với **Hetzner CX22** (~€8/tháng tổng). Khi traffic tăng >500 visits/ngày hoặc cần managed service, migrate lên Azure.

---

## ⚠️ 6. Rủi Ro & Rollback

### Phase 1 — Migration .NET 10 (rủi ro cao nhất)

| Rủi ro | Mức | Cách phòng / Rollback |
|--------|-----|----------------------|
| Migration kéo dài hơn dự kiến → chậm tiến độ | 🔴 HIGH | Dùng **strangler fig pattern**: migrate từng controller, chạy song song MVC5 + .NET 10. Mỗi controller migrate xong → test → switch. Không big-bang deploy |
| EF Core behavior khác EF6 → query sai kết quả | 🔴 HIGH | Viết integration test so sánh kết quả giữa EF6 và EF Core. Test từng repository method |
| Session mất khi chuyển auth → user bị logout | 🟡 MEDIUM | Thông báo trước cho khách, migrate vào giờ thấp điểm |

### Phase 2 — Security

| Rủi ro | Mức | Cách phòng / Rollback |
|--------|-----|----------------------|
| Hash password sai → không ai login được | 🔴 HIGH | Backup bảng User + Admin trước migration. Tạo cột `PasswordHash` mới, giữ cột `Password` cũ, chạy song song trước khi xóa |
| CSP header quá chặt → vỡ frontend | 🟡 MEDIUM | Test CSP với `Content-Security-Policy-Report-Only` trước khi enforce |

### Phase 4 — Production (EU)

| Rủi ro | Mức | Cách phòng / Rollback |
|--------|-----|----------------------|
| Stripe từ chối tài khoản (cần giấy tờ TBN) → không nhận thanh toán | 🔴 HIGH | Khách hàng TBN đứng tên đăng ký Stripe (cần NIF/CIF + tài khoản ngân hàng ES). Backup: PayPal hoạt động độc lập |
| VPS hỏng / mất dữ liệu | 🔴 HIGH | Backup daily + offsite. Hetzner có snapshot built-in. Test restore monthly |
| Domain .es bị chiếm / DNS lỗi | 🟡 MEDIUM | Mua domain ít nhất 2 năm, bật Cloudflare DNSSEC. Domain .es yêu cầu người đăng ký có liên kết với TBN |
| GDPR không compliant → bị phạt | 🔴 HIGH | Thuê luật sư TBN review legal docs. Implement đầy đủ consent log + right to be forgotten |
| IVA (VAT) tính sai → vấn đề với Hacienda | 🟠 HIGH | Test kỹ VAT calculation cho từng loại sản phẩm (21%/10%/4%). In hóa đơn VAT compliant |

### Phase 5 — i18n (Tây Ban Nha)

| Rủi ro | Mức | Cách phòng / Rollback |
|--------|-----|----------------------|
| Load 700 dictionary records mỗi request → chậm | 🟠 HIGH | Bắt buộc dùng `MemoryCache` ngay từ đầu |
| Quên dịch key → hiển thị mã `COL_CD` thay vì text | 🟡 LOW | Fallback: key không tồn tại trong ngôn ngữ hiện tại → trả về ES (ngôn ngữ gốc) |
| Tiếng Tây Ban Nha sai ngữ pháp / ngữ cảnh → khách hàng mất niềm tin | 🔴 HIGH | **Bắt buộc có native Spanish speaker review**. Không dùng Google Translate cho production! |

---

## 📅 7. Timeline Tổng Thể (16 Tuần / ~4 Tháng)

```
Tuần:  1  2  3  4  5  6  7  8  9  10 11 12 13 14 15 16
       ├───────────────┤  ├─────┤  ├──┤  ├──────────┤  ├──┤  ├──┤
       │   Phase 1     │  │Ph 2 │  │P3│  │  Phase 4 │  │P5│  │P6│P7│
       │ .NET 10 Migr  │  │Secur│  │SD│  │Product.R │  │i18│  │CK│GL│
       └───────────────┘  └─────┘  └──┘  └──────────┘  └──┘  └──┘└──┘
```

| Phase | Tuần | Duration | Mốc quan trọng |
|-------|------|----------|----------------|
| **1** | 1-6 | 6 tuần | App chạy .NET 10 local |
| **2** | 6-8 | 2 tuần | Bảo mật hoàn chỉnh |
| **3** | 8-9 | 1 tuần | Soft delete hoạt động |
| **4** | 9-11 | 2 tuần | App chạy production VPS |
| **5** | 11-14 | 3 tuần | 3 ngôn ngữ hoạt động |
| **6** | 14-15 | 1 tuần | Pass pre-launch checklist |
| **7** | 15-16 | 1 tuần | LIVE + ổn định |

---

## 📊 8. Bảng Theo Dõi Tiến Độ

| Phase | Tên | Trạng thái | Bắt đầu | Hoàn thành | Người phụ trách |
|-------|-----|-----------|---------|------------|----------------|
| 1 | .NET 10 Migration + Clean Architecture | ⬜ Chưa bắt đầu | - | - | - |
| 2 | Security Hardening | ⬜ Chưa bắt đầu | - | - | - |
| 3 | Soft Delete | ⬜ Chưa bắt đầu | - | - | - |
| 4 | Production Readiness | ⬜ Chưa bắt đầu | - | - | - |
| 5 | i18n — Đa ngôn ngữ | ⬜ Chưa bắt đầu | - | - | - |
| 6 | Pre-Launch Checklist | ⬜ Chưa bắt đầu | - | - | - |
| 7 | Go-Live & Post-Launch | ⬜ Chưa bắt đầu | - | - | - |

---

## 🎯 9. Quick Wins (Làm ngay cuối tuần này)

1. **Backup database** → copy `DBGiaDung.mdf` ra nơi an toàn
2. **Thêm `.gitignore`** → `.vs/`, `*.mdf`, `*.ldf`, `packages/`, `*.user`
3. **Xoay tất cả secrets đã leak trên git** (PayPal keys, email password)
4. **Đăng ký domain .es** + tạo Cloudflare account
5. **Đăng ký Stripe test mode** — làm quen với API
6. **Cài .NET 10 SDK** + tạo solution structure mới (Clean Architecture)
7. **Reverse-engineer DB** → generate EF Core entities
8. **Wrap checkout trong `TransactionScope`** trong code cũ (tạm thời)
9. **Xóa VNPay hoàn toàn khỏi codebase** (không dùng ở EU)

---

## 📝 10. Ghi Chú

- **Khách hàng là doanh nghiệp Tây Ban Nha** — mọi quyết định ưu tiên thị trường EU/ES
- Priority: **Bảo mật + GDPR > Data Integrity > Performance > Tính năng mới**
- **GDPR là bắt buộc** — không phải "nice to have". Mức phạt lên đến €20M hoặc 4% doanh thu
- Mỗi phase kết thúc phải có **demo được** (không chỉ "code xong")
- Design patterns học thuật (Template Method, Strategy, Decorator, Singleton, Facade) được giữ lại trong `Application/Patterns/` với comment rõ mục đích
- **Secrets đã leak trên git**: tạo repo mới cho production, không copy git history cũ
- **Tiếng Tây Ban Nha** là ngôn ngữ mặc định. Cần native speaker review trước go-live
- **Tiền tệ**: EUR (€) là chính. Hỗ trợ multi-currency nếu sau này mở rộng
- **Database**: PostgreSQL được khuyến nghị (miễn phí, đủ cho quy mô này). Nếu cần SQL Server → Azure SQL Basic ~€5/tháng
- **LOPDGDD**: Luật bảo vệ dữ liệu riêng của Tây Ban Nha — cần tuân thủ ngoài GDPR
- **Hóa đơn (Factura)**: Phải VAT compliant theo chuẩn Tây Ban Nha (số hóa đơn, NIF, base imponible, IVA, total)
