using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.Context;
namespace SportsStore.Service.Services
{
    public static class CartService
    {
        public static void AddItem(this Cart cart,Product product, int quantity)
        {
            UnitCart unitCart = new UnitCart
            {
                ProductID = product.ProductID,
                CartID = cart.CartID,
                Quantity = quantity,
            };

            cart.UnitCarts.Add(unitCart);
        }
        public static void RemoveLine(this Cart cart, Product product)
        {
            ((List<UnitCart>)cart.UnitCarts).RemoveAll(c => c.ProductID == product.ProductID);
        }

        public static decimal ComputeTotalValue(this Cart cart)
        {
            return cart.UnitCarts.Sum(i => 5);

            //i.product.Price * i.Quantity
        }
    }
}
