using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SportsStore.ViewModel.Models;
using SportsStore.Service.Services;
namespace SportsStore.WebUI.Binder
{
    public class CartModelBinder : IModelBinder
    {
        private const string sessionKey = "Cart";
        private CartService cartServ= new CartService();
        public object BindModel(ControllerContext controllerContext, ModelBindingContext
        bindingContext)
        {
            // get the Cart from the session
            CartViewModel cart = (CartViewModel)controllerContext.HttpContext.Session[sessionKey];

            // create the Cart if there wasn't one in the session data
            if (cart == null)
            {
                cart = new CartViewModel() { Cart = cartServ.GetNewCart((UserViewModel)controllerContext.HttpContext.Session["Auth"]) };
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            // return the cart
            return cart;
        }
    }
}