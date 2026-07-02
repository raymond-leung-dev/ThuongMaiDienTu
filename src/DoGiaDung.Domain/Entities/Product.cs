using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class Product : ISoftDeletable, IAuditable
{
    [Key]
    public int ProductId { get; set; }

    [Required, MaxLength(200)]
    public string ProductName { get; set; } = string.Empty;

    public decimal Price { get; set; }

    [MaxLength(1000)]
    public string? ImageLink { get; set; }

    public string? Description { get; set; }

    public int? Quantity { get; set; }

    public int? ProductStatus { get; set; }

    public decimal VatRate { get; set; } = VatRates.General; // Mặc định IVA 21%

    /// <summary>Giá đã bao gồm IVA</summary>
    [NotMapped]
    public decimal PriceWithVat => VatRates.PriceWithVat(Price, VatRate);

    // --- FK ---
    public int? CatalogId { get; set; }
    public int? TagId { get; set; }

    // --- Soft Delete ---
    [MaxLength(1)]
    public string DelYn { get; set; } = "N";

    // --- Audit ---
    [MaxLength(50)]
    public string? CreatedBy { get; set; }
    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;
    [MaxLength(50)]
    public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDt { get; set; }

    // --- Navigation ---
    public virtual Catalog? Catalog { get; set; }
    public virtual Tag? Tag { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
