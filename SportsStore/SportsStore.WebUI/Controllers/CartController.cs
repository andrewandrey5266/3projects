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
        private IProductRepository repository;
        public CartController(IProductRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            ViewBag.TotalPrice = new CartService().ComputeTotalValue((Cart)Session["Cart"]);
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
              new CartService().AddItem(cart,product, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productId, string returnUrl)
        {
            Product product = repository.Products
            .FirstOrDefault(p => p.ProductID == productId);
            if (product != null)
            {
                new CartService().RemoveLine(cart, product);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            ViewBag.TotalPrice = new CartService().ComputeTotalValue((Cart)Session["Cart"]);            
            return PartialView(cart);
        }

        private Cart GetCart()
        {
            Cart cart = (Cart)Session["Cart"];
            if (cart == null)
            {
                cart = new Cart() { OrderDate = System.DateTime.Now };
                Session["Cart"] = cart;
                new CartService().AddCartToDB(cart);
            }
            return cart;
        }

    }
}
