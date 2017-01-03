using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.Service.Interfaces;
using SportsStore.Context;
namespace SportsStore.Service.Services
{
    public class DiscountService : IDiscountService
    {
        EFDbContext context = new EFDbContext();
        public List<Discount> GetDiscounts()
        {
            return context.Discounts.ToList();
        }
    }
}
