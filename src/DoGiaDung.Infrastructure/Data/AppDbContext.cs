using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoGiaDung.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Admin> Admins => Set<Admin>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Catalog> Catalogs => Set<Catalog>();
    public DbSet<Order> Orders => Set<Order>();
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    public DbSet<News> News => Set<News>();
    public DbSet<Slide> Slides => Set<Slide>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<SysDictionary> SysDictionaries => Set<SysDictionary>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // === Global Query Filters cho Soft Delete ===
        // Tự động filter tất cả entity có ISoftDeletable với DEL_YN = 'N'
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType)) continue;

            var param = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
            var prop = System.Linq.Expressions.Expression.PropertyOrField(param, nameof(ISoftDeletable.DelYn));
            var equal = System.Linq.Expressions.Expression.Equal(prop,
                System.Linq.Expressions.Expression.Constant("N"));
            var lambda = System.Linq.Expressions.Expression.Lambda(equal, param);

            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(lambda);
        }

        // === Entity Configurations ===

        modelBuilder.Entity<Product>(e =>
        {
            e.ToTable("Product");
            e.HasKey(x => x.ProductId);
            e.Property(x => x.ProductName).HasMaxLength(200).IsRequired();
            e.Property(x => x.Price).HasColumnType("decimal(18,2)");
            e.Property(x => x.ImageLink).HasMaxLength(1000);
            e.Property(x => x.VatRate).HasColumnType("decimal(18,4)).HasDefaultValue(VatRates.General");
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
            e.HasOne(x => x.Catalog).WithMany(c => c.Products).HasForeignKey(x => x.CatalogId).OnDelete(DeleteBehavior.SetNull);
            e.HasOne(x => x.Tag).WithMany(t => t.Products).HasForeignKey(x => x.TagId).OnDelete(DeleteBehavior.SetNull);
        });

        modelBuilder.Entity<Catalog>(e =>
        {
            e.ToTable("Catalog");
            e.HasKey(x => x.CatalogId);
            e.Property(x => x.CatalogName).HasMaxLength(200).IsRequired();
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
        });

        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("User");
            e.HasKey(x => x.UserId);
            e.Property(x => x.UserName).HasMaxLength(100);
            e.Property(x => x.UserEmail).HasMaxLength(200);
            e.Property(x => x.PasswordHash).HasMaxLength(500).IsRequired();
            e.Property(x => x.UserAddress).HasMaxLength(500);
            e.Property(x => x.UserPhone).HasMaxLength(20);
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
            e.Property(x => x.ErrorLogin).HasMaxLength(500);
            e.HasMany(x => x.Transactions).WithOne(t => t.User).HasForeignKey(t => t.UserId);
            e.HasMany(x => x.Feedbacks).WithOne(f => f.User).HasForeignKey(f => f.UserId);
        });

        modelBuilder.Entity<Admin>(e =>
        {
            e.ToTable("Admin");
            e.HasKey(x => x.AdminId);
            e.Property(x => x.Username).HasMaxLength(50).IsRequired();
            e.Property(x => x.PasswordHash).HasMaxLength(500).IsRequired();
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
            e.HasMany(x => x.News).WithOne(n => n.Admin).HasForeignKey(n => n.AdminId);
        });

        modelBuilder.Entity<Order>(e =>
        {
            e.ToTable("Order");
            e.HasKey(x => x.OrderId);
            e.Property(x => x.Amount).HasColumnType("decimal(18,2)");
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
            e.HasOne(x => x.Product).WithMany(p => p.Orders).HasForeignKey(x => x.ProductId);
            e.HasOne(x => x.Transaction).WithMany(t => t.Orders).HasForeignKey(x => x.TransactionId);
        });

        modelBuilder.Entity<Transaction>(e =>
        {
            e.ToTable("Transaction");
            e.HasKey(x => x.TransactionId);
            e.Property(x => x.TransactionStatus)
                .HasConversion<string>()
                .HasMaxLength(20);
            e.Property(x => x.UserName).HasMaxLength(100);
            e.Property(x => x.UserEmail).HasMaxLength(200);
            e.Property(x => x.UserAddress).HasMaxLength(500);
            e.Property(x => x.UserPhone).HasMaxLength(20);
            e.Property(x => x.PaymentInfo).HasMaxLength(50);
            e.Property(x => x.Security).HasMaxLength(10);
            e.Property(x => x.Amount).HasColumnType("decimal(18,2)");
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
        });

        modelBuilder.Entity<Feedback>(e =>
        {
            e.ToTable("Feedback");
            e.HasKey(x => x.FeedbackId);
            e.Property(x => x.Message).HasMaxLength(500);
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
        });

        modelBuilder.Entity<News>(e =>
        {
            e.ToTable("News");
            e.HasKey(x => x.NewsId);
            e.Property(x => x.Title).HasMaxLength(200).IsRequired();
            e.Property(x => x.ImageLink).HasMaxLength(1000);
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
        });

        modelBuilder.Entity<Slide>(e =>
        {
            e.ToTable("Slide");
            e.HasKey(x => x.SlideId);
            e.Property(x => x.Title).HasMaxLength(200);
            e.Property(x => x.ImageLink).HasMaxLength(1000);
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
        });

        modelBuilder.Entity<Tag>(e =>
        {
            e.ToTable("Tag");
            e.HasKey(x => x.TagId);
            e.Property(x => x.TagName).HasMaxLength(100).IsRequired();
            e.Property(x => x.DelYn).HasMaxLength(1).HasDefaultValue("N");
        });

        modelBuilder.Entity<SysDictionary>(e =>
        {
            e.ToTable("SysDictionary");
            e.HasKey(x => x.DicId);
            e.Property(x => x.LngTp).HasMaxLength(10).IsRequired();
            e.Property(x => x.ColCd).HasMaxLength(100).IsRequired();
            e.Property(x => x.ColCdTp).HasMaxLength(50).HasDefaultValue("0");
            e.Property(x => x.ColCdTpNm).HasMaxLength(500).IsRequired();
            e.Property(x => x.RegDt).HasMaxLength(14);
            e.Property(x => x.ClsDt).HasMaxLength(14);
            e.Property(x => x.WorkMn).HasMaxLength(50);
            e.Property(x => x.WorkDt).HasMaxLength(14);
            e.Property(x => x.WorkIp).HasMaxLength(50);
            e.Property(x => x.CnfmSeq).HasMaxLength(50);
            e.Property(x => x.CnfmUser).HasMaxLength(50);
            e.Property(x => x.CnfmDt).HasMaxLength(14);
            e.Property(x => x.CnfmIp).HasMaxLength(50);
            e.Property(x => x.VsdTp).HasMaxLength(10);
            e.Property(x => x.Note).HasMaxLength(500);
            e.HasIndex(x => new { x.LngTp, x.ColCd, x.ColCdTp }).HasDatabaseName("IX_Dic_Lng_Col");
        });
    }

    public override int SaveChanges()
    {
        UpdateAuditableEntities();
        return base.SaveChanges();
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        UpdateAuditableEntities();
        return base.SaveChangesAsync(cancellationToken);
    }

    private void UpdateAuditableEntities()
    {
        foreach (var entry in ChangeTracker.Entries<IAuditable>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.CreatedDt = DateTime.UtcNow;
                    break;
                case EntityState.Modified:
                    entry.Entity.UpdatedDt = DateTime.UtcNow;
                    break;
            }
        }
    }
}
