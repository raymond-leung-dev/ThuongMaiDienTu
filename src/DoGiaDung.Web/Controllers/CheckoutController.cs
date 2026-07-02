using DoGiaDung.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoGiaDung.Web.Controllers;

[Authorize]
public class CheckoutController : Controller
{
    private readonly ICartService _cart;
    private readonly IOrderService _orders;

    public CheckoutController(ICartService cart, IOrderService orders)
    {
        _cart = cart;
        _orders = orders;
    }

    public IActionResult Index()
    {
        var cart = _cart.GetCart();
        if (cart.IsEmpty)
            return RedirectToAction("Index", "Cart");
        return View(cart);
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder(string address, string? message)
    {
        var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value ?? "";
        var name = User.Identity?.Name ?? "";
        var phone = "";

        var result = await _orders.CreateCheckoutAsync(email, name, phone, address, message);
        if (!result.IsSuccess)
        {
            ModelState.AddModelError("", result.Error ?? "Error desconocido");
            return View("Index", _cart.GetCart());
        }

        return Redirect(result.Data!);
    }

    public IActionResult Success(int tx)
    {
        ViewBag.TransactionId = tx;
        return View();
    }
}
