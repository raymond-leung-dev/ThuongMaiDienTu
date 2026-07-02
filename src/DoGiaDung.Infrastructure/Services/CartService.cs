using DoGiaDung.Application.DTOs;
using DoGiaDung.Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DoGiaDung.Infrastructure.Services;

public class CartService : Application.Interfaces.ICartService
{
    private readonly IHttpContextAccessor _http;
    private const string CartSessionKey = "Cart";

    public CartService(IHttpContextAccessor http) => _http = http;

    public CartDto GetCart()
    {
        var json = _http.HttpContext?.Session.GetString(CartSessionKey);
        return json == null ? new CartDto() : JsonSerializer.Deserialize<CartDto>(json) ?? new CartDto();
    }

    public void AddItem(int productId, string productName, decimal price, decimal priceWithVat, string? imageLink)
    {
        var cart = GetCart();
        var existing = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        if (existing != null)
            existing.Quantity++;
        else
            cart.Items.Add(new CartItemDto
            {
                ProductId = productId,
                ProductName = productName,
                Price = price,
                PriceWithVat = priceWithVat,
                Quantity = 1,
                ImageLink = imageLink
            });
        SaveCart(cart);
    }

    public void UpdateQuantity(int productId, int quantity)
    {
        var cart = GetCart();
        var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);
        if (item != null)
            item.Quantity = Math.Max(1, quantity);
        SaveCart(cart);
    }

    public void RemoveItem(int productId)
    {
        var cart = GetCart();
        cart.Items.RemoveAll(i => i.ProductId == productId);
        SaveCart(cart);
    }

    public void Clear()
    {
        _http.HttpContext?.Session.Remove(CartSessionKey);
    }

    private void SaveCart(CartDto cart)
    {
        var json = JsonSerializer.Serialize(cart);
        _http.HttpContext?.Session.SetString(CartSessionKey, json);
    }
}
