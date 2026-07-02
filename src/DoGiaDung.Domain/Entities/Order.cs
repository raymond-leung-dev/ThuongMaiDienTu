using System.ComponentModel.DataAnnotations;
using DoGiaDung.Domain.Interfaces;

namespace DoGiaDung.Domain.Entities;

public class Order : ISoftDeletable
{
    [Key]
    public int OrderId { get; set; }

    public int TransactionId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Amount { get; set; }
    public int OrderStatus { get; set; } = 1;

    [MaxLength(1)]
    public string DelYn { get; set; } = "N";

    public virtual Transaction? Transaction { get; set; }
    public virtual Product? Product { get; set; }
}
