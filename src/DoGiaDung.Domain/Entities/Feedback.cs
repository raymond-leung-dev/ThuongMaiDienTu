using System.ComponentModel.DataAnnotations;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class Feedback : ISoftDeletable
{
    [Key]
    public int FeedbackId { get; set; }

    public int? UserId { get; set; }

    [MaxLength(500)]
    public string? Message { get; set; }

    [MaxLength(1)]
    public string DelYn { get; set; } = "N";

    public virtual User? User { get; set; }
}
