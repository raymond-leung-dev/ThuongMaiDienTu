using DoGiaDung.Domain;
using DoGiaDung.Domain.Entities;
using DoGiaDung.Domain.Enums;
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

        // === Global soft-delete query filters ===
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(ISoftDeletable).IsAssignableFrom(entityType.ClrType)) continue;
            var param = System.Linq.Expressions.Expression.Parameter(entityType.ClrType, "e");
            var prop = System.Linq.Expressions.Expression.PropertyOrField(param, nameof(ISoftDeletable.DelYn));
            var equal = System.Linq.Expressions.Expression.Equal(prop,
                System.Linq.Expressions.Expression.Constant("N"));
            modelBuilder.Entity(entityType.ClrType).HasQueryFilter(
                System.Linq.Expressions.Expression.Lambda(equal, param));
        }

        // === Product ===
        modelBuilder.Entity<Product>(e =>
        {
            e.ToTable("PRODUCT");
            e.HasKey(x => x.ProductId);
            e.Property(x => x.ProductId).HasColumnName("product_id").ValueGeneratedOnAdd();
            e.Property(x => x.ProductName).HasColumnName("product_name").HasMaxLength(200);
            e.Property(x => x.Price).HasColumnName("price").HasColumnType("decimal(18,2)");
            e.Property(x => x.Description).HasColumnName("description").HasMaxLength(500);
            e.Property(x => x.Quantity).HasColumnName("quantity");
            e.Property(x => x.ProductStatus).HasColumnName("product_status");
            e.Property(x => x.ImageLink).HasColumnName("image_link").HasMaxLength(1000);
            e.Property(x => x.CatalogId).HasColumnName("catalog_id");
            e.Property(x => x.TagId).HasColumnName("tag_id");
            // New columns (add via migration)
            e.Property(x => x.VatRate).HasColumnName("vat_rate").HasColumnType("decimal(18,4)").HasDefaultValue(VatRates.General);
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            e.Property(x => x.CreatedBy).HasColumnName("created_by").HasMaxLength(50);
            e.Property(x => x.CreatedDt).HasColumnName("created_dt");
            e.Property(x => x.UpdatedBy).HasColumnName("updated_by").HasMaxLength(50);
            e.Property(x => x.UpdatedDt).HasColumnName("updated_dt");
            e.HasOne(x => x.Catalog).WithMany(c => c.Products).HasForeignKey(x => x.CatalogId);
            e.HasOne(x => x.Tag).WithMany(t => t.Products).HasForeignKey(x => x.TagId);
            // Ignore old columns we don't use
            e.Ignore(x => x.PriceWithVat);
        });

        // === Catalog ===
        modelBuilder.Entity<Catalog>(e =>
        {
            e.ToTable("CATALOG");
            e.HasKey(x => x.CatalogId);
            e.Property(x => x.CatalogId).HasColumnName("catalog_id").ValueGeneratedOnAdd();
            e.Property(x => x.CatalogName).HasColumnName("catalog_name").HasMaxLength(200);
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            e.Property(x => x.CreatedBy).HasColumnName("created_by").HasMaxLength(50);
            e.Property(x => x.CreatedDt).HasColumnName("created_dt");
            e.Property(x => x.UpdatedBy).HasColumnName("updated_by").HasMaxLength(50);
            e.Property(x => x.UpdatedDt).HasColumnName("updated_dt");
            // Ignore old columns
            e.Ignore("parent_id");
            e.Ignore("sort_order");
        });

        // === User ===
        modelBuilder.Entity<User>(e =>
        {
            e.ToTable("USER");
            e.HasKey(x => x.UserId);
            e.Property(x => x.UserId).HasColumnName("user_id").ValueGeneratedOnAdd();
            e.Property(x => x.UserName).HasColumnName("user_name").HasMaxLength(100);
            e.Property(x => x.UserEmail).HasColumnName("user_email").HasMaxLength(200);
            e.Property(x => x.PasswordHash).HasColumnName("password").HasMaxLength(500);
            e.Property(x => x.UserAddress).HasColumnName("user_address").HasMaxLength(500);
            e.Property(x => x.UserPhone).HasColumnName("user_phone").HasMaxLength(20);
            e.Property(x => x.ResetPasswordCode).HasColumnName("resetPasswordCode").HasMaxLength(100);
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            e.Property(x => x.CreatedBy).HasColumnName("created_by").HasMaxLength(50);
            e.Property(x => x.CreatedDt).HasColumnName("created_dt");
            e.Property(x => x.UpdatedBy).HasColumnName("updated_by").HasMaxLength(50);
            e.Property(x => x.UpdatedDt).HasColumnName("updated_dt");
            // ConfirmPassword and ErrorLogin are [NotMapped] — not in DB
            e.Ignore(x => x.ConfirmPassword);
            e.Ignore(x => x.ErrorLogin);
            e.HasMany(x => x.Transactions).WithOne(t => t.User).HasForeignKey(t => t.UserId);
            e.HasMany(x => x.Feedbacks).WithOne(f => f.User).HasForeignKey(f => f.UserId);
        });

        // === Admin ===
        modelBuilder.Entity<Admin>(e =>
        {
            e.ToTable("ADMIN");
            e.HasKey(x => x.AdminId);
            e.Property(x => x.AdminId).HasColumnName("admin_id").ValueGeneratedOnAdd();
            e.Property(x => x.Username).HasColumnName("username").HasMaxLength(50);
            e.Property(x => x.PasswordHash).HasColumnName("password").HasMaxLength(500);
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            e.Property(x => x.CreatedBy).HasColumnName("created_by").HasMaxLength(50);
            e.Property(x => x.CreatedDt).HasColumnName("created_dt");
            e.Property(x => x.UpdatedBy).HasColumnName("updated_by").HasMaxLength(50);
            e.Property(x => x.UpdatedDt).HasColumnName("updated_dt");
            e.HasMany(x => x.News).WithOne(n => n.Admin).HasForeignKey(n => n.AdminId);
        });

        // === Order ===
        modelBuilder.Entity<Order>(e =>
        {
            e.ToTable("ORDER");
            e.HasKey(x => x.OrderId);
            e.Property(x => x.OrderId).HasColumnName("order_id").ValueGeneratedOnAdd();
            e.Property(x => x.TransactionId).HasColumnName("transaction_id");
            e.Property(x => x.ProductId).HasColumnName("product_id");
            e.Property(x => x.Quantity).HasColumnName("quantity");
            e.Property(x => x.Amount).HasColumnName("amout").HasColumnType("decimal(18,2)");
            e.Property(x => x.OrderStatus).HasColumnName("order_status");
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            e.HasOne(x => x.Product).WithMany(p => p.Orders).HasForeignKey(x => x.ProductId);
            e.HasOne(x => x.Transaction).WithMany(t => t.Orders).HasForeignKey(x => x.TransactionId);
        });

        // === Transaction ===
        modelBuilder.Entity<Transaction>(e =>
        {
            e.ToTable("TRANSACTION");
            e.HasKey(x => x.TransactionId);
            e.Property(x => x.TransactionId).HasColumnName("transaction_id").ValueGeneratedOnAdd();
            e.Property(x => x.UserId).HasColumnName("user_id");
            e.Property(x => x.UserName).HasColumnName("user_name").HasMaxLength(100);
            e.Property(x => x.UserEmail).HasColumnName("user_email").HasMaxLength(200);
            e.Property(x => x.UserPhone).HasColumnName("user_phone").HasMaxLength(20);
            e.Property(x => x.UserAddress).HasColumnName("user_address").HasMaxLength(500);
            e.Property(x => x.Message).HasColumnName("message").HasMaxLength(500);
            e.Property(x => x.Amount).HasColumnName("amount").HasColumnType("decimal(18,2)");
            e.Property(x => x.Payment).HasColumnName("payment");
            e.Property(x => x.PaymentInfo).HasColumnName("payment_info").HasMaxLength(50);
            e.Property(x => x.Security).HasColumnName("security").HasMaxLength(10);
            e.Property(x => x.TransactionCreated).HasColumnName("transaction_created");
            e.Property(x => x.TransactionStatus).HasColumnName("transaction_status")
                .HasConversion<int>();
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            e.Property(x => x.CreatedBy).HasColumnName("created_by").HasMaxLength(50);
            e.Property(x => x.CreatedDt).HasColumnName("created_dt");
            e.Property(x => x.UpdatedBy).HasColumnName("updated_by").HasMaxLength(50);
            e.Property(x => x.UpdatedDt).HasColumnName("updated_dt");
        });

        // === Feedback ===
        modelBuilder.Entity<Feedback>(e =>
        {
            e.ToTable("FEEDBACK");
            e.HasKey(x => x.FeedbackId);
            e.Property(x => x.FeedbackId).HasColumnName("feedback_id").ValueGeneratedOnAdd();
            e.Property(x => x.UserId).HasColumnName("user_id");
            // Message maps to feedback_conten (existing column in old DB)
            e.Property(x => x.Message).HasColumnName("feedback_conten").HasMaxLength(500);
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            // Ignore extra old columns we don't use
            e.Ignore("user_name");
            e.Ignore("user_email");
            e.Ignore("user_phone");
            e.Ignore("user_address");
            e.Ignore("feedback_created");
        });

        // === News ===
        modelBuilder.Entity<News>(e =>
        {
            e.ToTable("NEW");
            e.HasKey(x => x.NewsId);
            e.Property(x => x.NewsId).HasColumnName("new_id").ValueGeneratedOnAdd();
            e.Property(x => x.Title).HasColumnName("tittle").HasMaxLength(200);
            e.Property(x => x.Content).HasColumnName("detail");
            e.Property(x => x.ImageLink).HasColumnName("new_image").HasMaxLength(1000);
            e.Property(x => x.CreatedDate).HasColumnName("new_created");
            e.Property(x => x.AdminId).HasColumnName("new_created_by");
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            e.Property(x => x.CreatedBy).HasColumnName("created_by").HasMaxLength(50);
            e.Property(x => x.CreatedDt).HasColumnName("created_dt");
            e.Property(x => x.UpdatedBy).HasColumnName("updated_by").HasMaxLength(50);
            e.Property(x => x.UpdatedDt).HasColumnName("updated_dt");
            // Ignore old columns
            e.Ignore("tag_id");
            e.Ignore("new_catalog_id");
        });

        // === Slide ===
        modelBuilder.Entity<Slide>(e =>
        {
            e.ToTable("SLIDE");
            e.HasKey(x => x.SlideId);
            e.Property(x => x.SlideId).HasColumnName("slide_id").ValueGeneratedOnAdd();
            e.Property(x => x.Title).HasColumnName("description").HasMaxLength(200);
            e.Property(x => x.ImageLink).HasColumnName("image").HasMaxLength(1000);
            e.Property(x => x.SortOrder).HasColumnName("slide_order");
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
            // Ignore extra old columns
            e.Ignore("link");
        });

        // === Tag ===
        modelBuilder.Entity<Tag>(e =>
        {
            e.ToTable("TAG");
            e.HasKey(x => x.TagId);
            e.Property(x => x.TagId).HasColumnName("tag_id").ValueGeneratedOnAdd();
            e.Property(x => x.TagName).HasColumnName("tag_name").HasMaxLength(100);
            e.Property(x => x.DelYn).HasColumnName("del_yn").HasMaxLength(1).HasDefaultValue("N");
        });

        // === SysDictionary (NEW table) ===
        modelBuilder.Entity<SysDictionary>(e =>
        {
            e.ToTable("SYS_DICTIONARY");
            e.HasKey(x => x.DicId);
            e.Property(x => x.DicId).HasColumnName("dic_id").ValueGeneratedOnAdd();
            e.Property(x => x.LngTp).HasColumnName("lng_tp").HasMaxLength(10).IsRequired();
            e.Property(x => x.ColCd).HasColumnName("col_cd").HasMaxLength(100).IsRequired();
            e.Property(x => x.ColCdTp).HasColumnName("col_cd_tp").HasMaxLength(50).HasDefaultValue("0");
            e.Property(x => x.ColCdTpNm).HasColumnName("col_cd_tp_nm").HasMaxLength(500).IsRequired();
            e.Property(x => x.SortSeq).HasColumnName("sort_seq").HasDefaultValue(1);
            e.Property(x => x.RegDt).HasColumnName("reg_dt").HasMaxLength(14);
            e.Property(x => x.ClsDt).HasColumnName("cls_dt").HasMaxLength(14);
            e.Property(x => x.WorkMn).HasColumnName("work_mn").HasMaxLength(50);
            e.Property(x => x.WorkDt).HasColumnName("work_dt").HasMaxLength(14);
            e.Property(x => x.WorkIp).HasColumnName("work_ip").HasMaxLength(50);
            e.Property(x => x.CnfmSeq).HasColumnName("cnfm_seq").HasMaxLength(50);
            e.Property(x => x.CnfmUser).HasColumnName("cnfm_user").HasMaxLength(50);
            e.Property(x => x.CnfmDt).HasColumnName("cnfm_dt").HasMaxLength(14);
            e.Property(x => x.CnfmIp).HasColumnName("cnfm_ip").HasMaxLength(50);
            e.Property(x => x.VsdTp).HasColumnName("vsd_tp").HasMaxLength(10);
            e.Property(x => x.Note).HasColumnName("note").HasMaxLength(500);
            e.HasIndex(x => new { x.LngTp, x.ColCd, x.ColCdTp }).HasDatabaseName("ix_dic_lng_col");
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
