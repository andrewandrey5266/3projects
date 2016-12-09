using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.ViewModel.Models;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using SportsStore.Service.Interfaces;

namespace SportsStore.Service.Services 
{
    public class UnitCartService : IUnitCartService
    {
        public EFDbContext context;

        public UnitCartService()
        {
            this.context = new EFDbContext();
        }

        public void AddItem(CartViewModel cartVM)
        {
            if (SelectUnitCarts(cartVM).Count() > 0)
            {
                SelectUnitCarts(cartVM).ForEach(i => i.Quantity = i.Quantity + 1);
                context.SaveChanges();
                return;
            }

            context.UnitCarts.Add(new UnitCart
            {
                Cart = cartVM.Cart,
                Quantity = 1,
                Product = context.Products.Where(i => i.Id == cartVM.ProductId).First()
            });

            context.SaveChanges();
        }

        public void RemoveItem(CartViewModel cartProductVM)
        {
            context.UnitCarts.RemoveRange(SelectUnitCarts(cartProductVM));
            context.SaveChanges();
        }

        private List<UnitCart> SelectUnitCarts(CartViewModel cartProductVM)
        {
            return context.UnitCarts.Where(i => i.Cart.Id == cartProductVM.Cart.Id
                 && i.Product.Id == cartProductVM.ProductId).ToList();
        }
             
    }
}
