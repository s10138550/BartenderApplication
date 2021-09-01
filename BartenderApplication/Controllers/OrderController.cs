using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BartenderApplication.Infrastructure;
using BartenderApplication.Models;
using BartenderApplication.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private IMenuRepository repository;
        public CartController(IMenuRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Order = GetOrder(),
                ReturnUrl = returnUrl
            });
        }
        public RedirectToActionResult AddToCart(int productId, string returnUrl)
        {
            Menu product = repository.Menu
            .FirstOrDefault(p => p.MenuID == productId);
            if (product != null)
            {
                Order cart = GetOrder();
                cart.AddItem(product, 1);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Menu product = repository.Menu
            .FirstOrDefault(p => p.MenuID == productId);
            if (product != null)
            {
                Order cart = GetOrder();
                cart.RemoveLine(product);
                SaveCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        private Order GetOrder()
        {
            Order cart = HttpContext.Session.GetJson<Order>("Order") ?? new Order();
            return cart;
        }
        private void SaveCart(Order cart)
        {
            HttpContext.Session.SetJson("Order", cart);
        }
    }
}
