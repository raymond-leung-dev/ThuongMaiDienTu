using System.ComponentModel.DataAnnotations;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class Catalog : ISoftDeletable, IAuditable
{
    [Key]
    public int CatalogId { get; set; }

    [Required, MaxLength(100)]
    public string CatalogName { get; set; } = string.Empty;

    [MaxLength(1)]
    public string DelYn { get; set; } = "N";

    [MaxLength(50)] public string? CreatedBy { get; set; }
    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;
    [MaxLength(50)] public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
