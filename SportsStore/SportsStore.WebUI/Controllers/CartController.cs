﻿using System.Linq;
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
        
        public CartController(IUnitCartService unitCartServ, ICartService cartServ)
        {
            repository = new EFDbContext();
            this.unitCartServ = unitCartServ;
            this.cartService = cartServ;

        }

        public ViewResult Index(CartViewModel cart, string returnUrl)
        {
            cart = GetCart();
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
            cart = GetCart();
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

        public PartialViewResult Summary(CartViewModel cartVM)
        {
            if (cartVM.Cart == null) 
                cartVM = GetCart();
            ViewBag.TotalPrice = cartService.ComputeTotalValue(cartVM);
            ViewBag.NumOfProducs = cartService.GetProductQuantity(cartVM);
            return PartialView(cartVM);
        }

        private CartViewModel GetCart()
        {
            CartViewModel cartVM = (CartViewModel)Session["Cart"];
            if (cartVM == null)
            {
                cartVM = new CartViewModel { Cart = cartService.GetNewCart() };
                Session["Cart"] = cartVM;         
            }
            return cartVM;
        }

    }
}
