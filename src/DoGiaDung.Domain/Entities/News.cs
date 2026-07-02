using System.ComponentModel.DataAnnotations;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class News : ISoftDeletable, IAuditable
{
    [Key]
    public int NewsId { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Content { get; set; }

    [MaxLength(1000)]
    public string? ImageLink { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    public int? AdminId { get; set; }

    [MaxLength(1)] public string DelYn { get; set; } = "N";
    [MaxLength(50)] public string? CreatedBy { get; set; }
    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;
    [MaxLength(50)] public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDt { get; set; }

    public virtual Admin? Admin { get; set; }
}
