using System.ComponentModel.DataAnnotations;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class Slide : ISoftDeletable
{
    [Key]
    public int SlideId { get; set; }

    [MaxLength(200)]
    public string? Title { get; set; }

    [MaxLength(1000)]
    public string? ImageLink { get; set; }

    public int? SortOrder { get; set; }

    [MaxLength(1)]
    public string DelYn { get; set; } = "N";
}
