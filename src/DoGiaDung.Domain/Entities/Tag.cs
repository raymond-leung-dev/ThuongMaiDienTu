using System.ComponentModel.DataAnnotations;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class Tag : ISoftDeletable
{
    [Key]
    public int TagId { get; set; }

    [Required, MaxLength(100)]
    public string TagName { get; set; } = string.Empty;

    [MaxLength(1)]
    public string DelYn { get; set; } = "N";

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
