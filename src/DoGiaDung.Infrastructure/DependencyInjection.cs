using DoGiaDung.Application.Interfaces;
using DoGiaDung.Domain.Interfaces;
using DoGiaDung.Infrastructure.Data;
using DoGiaDung.Infrastructure.Email;
using DoGiaDung.Infrastructure.Payment;
using DoGiaDung.Infrastructure.Repositories;
using DoGiaDung.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DoGiaDung.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        // ---- Database ----
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(connectionString));

        // ---- Repositories ----
        services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));

        // ---- Services ----
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<Application.Interfaces.ICartService, CartService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IPaymentService, StripePaymentService>();
        services.AddScoped<IEmailService, SmtpEmailService>();
        services.AddScoped<IDictionaryService, CachedDictionaryService>();

        return services;
    }
}
