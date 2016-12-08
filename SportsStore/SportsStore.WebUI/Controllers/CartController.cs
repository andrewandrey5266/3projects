using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using SportsStore.Service.Services;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private EFDbContext repository = new EFDbContext();
        private CartService cartService = new CartService();
        
        public ViewResult Index(CartViewModel cart, string returnUrl)
        {
            ViewBag.TotalPrice = new CartService().ComputeTotalValue((Cart)Session["Cart"]);
            return View(new CartIndexViewModel
            {
                CartVM = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(CartViewModel cart, string productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
              cartService.AddItem(cart,product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(CartViewModel cart, string productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.Id == productId);
            if (product != null)
            {
                cartService.RemoveLine(cart, product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(CartViewModel cart)
        {
            ViewBag.TotalPrice = new CartService().ComputeTotalValue((Cart)Session["Cart"]);            
            return PartialView(cart);
        }

        private CartViewModel GetCart()
        {
            CartViewModel cartVM = (CartViewModel)Session["Cart"];
            if (cartVM == null)
            {
                cartVM = new CartViewModel { cart = cartService.GetNewCart() };
                Session["Cart"] = cartVM;         
            }
            return cartVM;
        }

    }
}
