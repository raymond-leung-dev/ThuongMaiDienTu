using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class User : ISoftDeletable, IAuditable
{
    [Key]
    public int UserId { get; set; }

    [Required, MaxLength(100)]
    public string UserName { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    [EmailAddress]
    public string UserEmail { get; set; } = string.Empty;

    [Required, MaxLength(200)]
    public string PasswordHash { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? UserAddress { get; set; }

    [MaxLength(20)]
    public string? UserPhone { get; set; }

    [MaxLength(200)]
    public string? ResetPasswordCode { get; set; }

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
    public virtual ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    // --- NotMapped ---
    [NotMapped]
    public string? ConfirmPassword { get; set; }

    [NotMapped]
    public string? ErrorLogin { get; set; }
}
