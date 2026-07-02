using DoGiaDung.Application;
using DoGiaDung.Infrastructure;
using Microsoft.AspNetCore.RateLimiting;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// ---- DI Registrations ----
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

// ---- Cookie Auth ----
builder.Services.AddAuthentication(Microsoft.AspNetCore.Authentication.Cookies
    .CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Index";
        options.LogoutPath = "/User/Logout";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
    });

// ---- Localization (ES default) ----
builder.Services.AddLocalization();
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "es", "en", "vi" };
    options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization
        .RequestCulture("es", "es");
    options.SetDefaultCulture("es");
    options.SupportedCultures = supportedCultures
        .Select(c => new System.Globalization.CultureInfo(c)).ToList();
    options.SupportedUICultures = options.SupportedCultures;
});

// ---- Rate Limiting ----
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter("Login", cfg =>
    {
        cfg.PermitLimit = 5;
        cfg.Window = TimeSpan.FromMinutes(15);
    });
    options.AddFixedWindowLimiter("ForgotPassword", cfg =>
    {
        cfg.PermitLimit = 3;
        cfg.Window = TimeSpan.FromMinutes(60);
    });
    options.RejectionStatusCode = 429;
});

// ---- Memory Cache (for DictionaryService) ----
builder.Services.AddMemoryCache();

var app = builder.Build();

// ---- Middleware Pipeline ----
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseRateLimiter();

// ---- Localization ----
app.UseRequestLocalization();

app.UseAuthentication();
app.UseAuthorization();

// ---- Security Headers ----
app.Use(async (context, next) =>
{
    context.Response.Headers.Append("X-Frame-Options", "DENY");
    context.Response.Headers.Append("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Append("Referrer-Policy", "strict-origin-when-cross-origin");
    context.Response.Headers.Append("Permissions-Policy",
        "camera=(), microphone=(), geolocation=()");
    await next();
});

// ---- Routes ----
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
