using System.ComponentModel.DataAnnotations;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class Admin : ISoftDeletable, IAuditable
{
    [Key]
    public int AdminId { get; set; }

    [Required, MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string PasswordHash { get; set; } = string.Empty;

    [MaxLength(1)]
    public string DelYn { get; set; } = "N";

    [MaxLength(50)] public string? CreatedBy { get; set; }
    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;
    [MaxLength(50)] public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDt { get; set; }

    public virtual ICollection<News> News { get; set; } = new List<News>();
}
