using DoGiaDung.Application.Common;
using DoGiaDung.Application.DTOs;

namespace DoGiaDung.Application.Interfaces;

public interface ICartService
{
    CartDto GetCart();
    void AddItem(int productId, string productName, decimal price, decimal priceWithVat, string? imageLink);
    void UpdateQuantity(int productId, int quantity);
    void RemoveItem(int productId);
    void Clear();
}
