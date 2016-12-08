using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using System.Data.Entity;
using SportsStore.W
namespace SportsStore.Service.Services
{
    public class CartService
    {
        public EFDbContext context = new EFDbContext();
  
        public void AddCartToDB(Cart cart)
        {
            //context.Carts.Add(cart);
        }
        public void AddItem(CartViewModel cart,Product product, int quantity)//itemveiwmodul
        {
            
        }
        public void RemoveLine(Cart cart, Product product)
        {
           
        }

        public decimal ComputeTotalValue(Cart cart)
        {
            return 0;
                //context.UnitCarts
                //.Where(i => i.Cart.Id == cart.Id)
                //.Sum(i => i.product.Price * i.Quantity);
        }

        public Cart GetNewCart()
        {
            Cart cart = new Cart { OrderDate = DateTime.Now };

            context.Carts.Add(cart);

            return cart;
        }
    }
}
