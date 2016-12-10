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
    public class CartService:ICartService
    {
        public EFDbContext context = new EFDbContext();
         
        public decimal ComputeTotalValue(CartViewModel cartVM)
        {
            return context.UnitCarts
                .Where(i => i.Cart.Id == cartVM.Cart.Id)
                .Select(i => i.Product.Price * i.Quantity)
                .DefaultIfEmpty()
                .Sum();          
        }

        public int GetProductQuantity(CartViewModel cartVM)
        {
            return context.UnitCarts
                .Where(i => i.Cart.Id == cartVM.Cart.Id)
                .Count();
        }

        public Cart GetNewCart()
        {
            Cart cart = new Cart { OrderDate = DateTime.Now };

            context.Carts.Add(cart);
            context.SaveChanges();

            return cart;
        }

      

      
    }
}
