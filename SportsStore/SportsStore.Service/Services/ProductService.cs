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
    public class ProductService: IProductService
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
        public List<Product> GetProduct()
        {
            return context.Products.Include("Category").ToList();
        }        
        public void SaveProduct(Product product)
        {
            var prod = context.Products.Find(product.Id);

            if (prod != null)
            {
                context.Products.Include("Category").Where(i => i.Id == prod.Id);
                context.Products.Remove(prod);
            }
            
            context.Products.Add(product);
            context.SaveChanges();
        }        
        public Product DeleteProduct(string productId)
        {
            var product = context.Products.Find(productId);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            return product;
        }
    }
}
