using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.ViewModel.Models;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using SportsStore.Service.Interfaces;
using System.Data.Linq;
using System.Data.Entity;
namespace SportsStore.Service.Services
{
    public class CartService : ICartService
    {
        public EFDbContext context = new EFDbContext();
         
        public decimal ComputeTotalValue(CartViewModel cartVM)
        {
            var delivPrice =  cartVM.Cart.Delivery != null? cartVM.Cart.Delivery.DeliveryPrice : 0;
                     
            return context.UnitCarts
                .Where(i => i.Cart.Id == cartVM.Cart.Id)
                .Select(i => i.Product.Price * i.Quantity 
                    - i.Product.Price * i.Quantity * i.Product.Discount.Percentage / 100)
                .DefaultIfEmpty()
                .Sum() + delivPrice;          
        }

        public int GetProductQuantity(CartViewModel cartVM)
        {
            return context.UnitCarts
                .Where(i => i.Cart.Id == cartVM.Cart.Id)
                .Count();
        }

        public Cart GetNewCart(UserViewModel user)
        {
            Cart cart = new Cart
            {
                OrderDate = DateTime.Now,
                User = context.Users
                .Where(i => i.Id == user.Id)
                .First()
            };

            context.Carts.Add(cart);
            context.SaveChanges();

            return cart;
        }


        public void CompleteCart(CartViewModel cartVM, string deliveryId)
        {
            var cart = context.Carts.Where(i => i.Id == cartVM.Cart.Id).FirstOrDefault();
            if (cart != null)
            {
                cart.Delivery = context.Deliveries.Where(i => i.Id == deliveryId).First();
                cart.TotalPrice = ComputeTotalValue(cartVM);
            }

            context.SaveChanges();
        }
    }
}
