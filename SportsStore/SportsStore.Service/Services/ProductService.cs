using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.ViewModel.Models;
using SportsStore.Service.Interfaces;
using SportsStore.Context;
using SportsStore.Domain.Entities;

namespace SportsStore.Service.Services
{
    public class ProductService
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Product> GetProduct(string category, int PageSize, int page)
        {
            return context.Products
                  .Where(p => category == null || p.Category.Name == category)
                  .OrderBy(p => p.Id)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize);
        }

    }
}
