using System.Linq;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using SportsStore.Service.Interfaces;
using SportsStore.ViewModel.Models;
using SportsStore.Service.Services;

namespace SportsStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private EFDbContext repository;
        private ICartService cartService;
        private IUnitCartService unitCartServ;
        private IDeliveryService delivertyServ;
        public CartController(IUnitCartService unitCartServ, ICartService cartServ, IDeliveryService delivServ)
        {
            repository = new EFDbContext();
            this.unitCartServ = unitCartServ;
            this.cartService = cartServ;
            this.delivertyServ = delivServ;
        }

        public PartialViewResult Summary(CartViewModel cartVM)
        {
            if (cartVM.Cart == null)
                cartVM = GetCart();
            ViewBag.TotalPrice = cartService.ComputeTotalValue(cartVM);
            var num = cartService.GetProductQuantity(cartVM); ;
            ViewBag.NumOfProducts = cartService.GetProductQuantity(cartVM);
            return PartialView(cartVM);
        }

        public ViewResult Index(CartViewModel cart, string returnUrl)
        {
           ViewBag.TotalPrice = cartService.ComputeTotalValue(cart);


            return View(new CartViewModel
            {
                Cart = cart.Cart,
                ReturnUrl = returnUrl,
                UnitCarts = unitCartServ.SelectUnitCarts(cart)
            });
        }
        public RedirectToRouteResult AddToCart(CartViewModel cart, string Id, string returnUrl)
        {
            if (cart.Cart == null)
                cart = GetCart();
            cart.ProductId = Id;
            ///
            Product product = repository.Products
            .FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
               unitCartServ.AddItem(cart);
            }
            return RedirectToAction("Index", new { cart, returnUrl });
        }
        public RedirectToRouteResult RemoveFromCart(CartViewModel cart, string Id, string returnUrl)
        {
            cart.ProductId = Id;
///
            Product product = repository.Products
            .FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                unitCartServ.RemoveItem(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        public ViewResult Checkout()
        {
            return View(new DeliveryViewModel());
        }

        [HttpPost]
        public ViewResult Checkout(CartViewModel cart, DeliveryViewModel deliveryVM)
        {

            if (cartService.GetProductQuantity(cart) == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }
            if (ModelState.IsValid)
            {
                delivertyServ.SaveDelivery(deliveryVM,cart);
                Session["Cart"] = null;
                
                return View("Completed", deliveryVM);
            }
            else
            {
                return View(new DeliveryViewModel());
            }
        }
        
        private CartViewModel GetCart()
        {
            CartViewModel cartVM = (CartViewModel)Session["Cart"];
            if (cartVM == null)
            {
                cartVM = new CartViewModel { Cart = cartService.GetNewCart((UserViewModel)Session["Auth"]) };
                Session["Cart"] = cartVM;         
            }
            return cartVM;
        }

    }
}
