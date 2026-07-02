namespace DoGiaDung.Application.DTOs;

public class CartItemDto
{
    public int ProductId { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public decimal PriceWithVat { get; set; }
    public int Quantity { get; set; }
    public string? ImageLink { get; set; }
    public decimal Total => Quantity * PriceWithVat;
}

public class CartDto
{
    public List<CartItemDto> Items { get; set; } = new();
    public decimal Total => Items.Sum(i => i.Total);
    public bool IsEmpty => !Items.Any();
}
