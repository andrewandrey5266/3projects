using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Service.Interfaces;
using SportsStore.ViewModel.Models;
using SportsStore.Domain.Entities;
using SportsStore.Context;
namespace SportsStore.Service.Services
{
    public class DeliveryService :IDeliveryService
    {
        private EFDbContext context = new EFDbContext();

        public void SaveDelivery(DeliveryViewModel deliv)
        {
            context.Deliveries.Add(new Delivery
            {
                DeliveryPrice = deliv.DeliveryPrice,
                City = deliv.City,
                Street = deliv.Street,
                HomeNumber = deliv.HomeNumber,
                Appartment = deliv.Appartment,
                PostIndex = deliv.PostIndex,
                Cart = deliv.Cart
            });
            context.SaveChanges();
        }
    }
}
