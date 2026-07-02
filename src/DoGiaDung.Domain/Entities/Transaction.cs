using System.ComponentModel.DataAnnotations;
using DoGiaDung.Domain.Enums;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class Transaction : ISoftDeletable, IAuditable
{
    [Key]
    public int TransactionId { get; set; }

    public int UserId { get; set; }

    public TransactionStatus TransactionStatus { get; set; } = TransactionStatus.Pending;

    [MaxLength(100)] public string? UserName { get; set; }
    [MaxLength(200)] public string? UserEmail { get; set; }
    [MaxLength(500)] public string? UserAddress { get; set; }
    [MaxLength(20)] public string? UserPhone { get; set; }
    public string? Message { get; set; }

    public DateTime TransactionCreated { get; set; } = DateTime.UtcNow;

    /// <summary>1=COD (not used in EU), 2=PayPal, 3=Stripe</summary>
    public int Payment { get; set; }

    [MaxLength(50)] public string? PaymentInfo { get; set; }
    [MaxLength(10)] public string? Security { get; set; }
    public decimal Amount { get; set; }

    [MaxLength(1)] public string DelYn { get; set; } = "N";

    [MaxLength(50)] public string? CreatedBy { get; set; }
    public DateTime CreatedDt { get; set; } = DateTime.UtcNow;
    [MaxLength(50)] public string? UpdatedBy { get; set; }
    public DateTime? UpdatedDt { get; set; }

    public virtual User? User { get; set; }
    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
