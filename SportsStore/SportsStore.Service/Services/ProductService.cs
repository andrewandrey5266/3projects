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
                  .Include("Discount")
                  .Where(p => category == null || p.Category.Name == category)
                  .OrderBy(p => p.Id)
                  .Skip((page - 1) * PageSize)
                  .Take(PageSize);
        }
        public List<Product> GetProducts()
        {
            return context.Products
                .Include("Category")
                .Include("Discount")
                .ToList();
        }

        public IEnumerable<ProductViewModel> GetProductsVM()
        {
            var a = context.Products
                .Include("Category")
                .Include("Discount")
                .ToList();
            var result = new List<ProductViewModel>();
            foreach (var c in a)
            {
                result.Add(new ProductViewModel(c));
            }
            return result;

        }

        public Product GetProduct(string id)
        {
            return GetProducts().Where(i => i.Id == id).First();
        }
        public void SaveProduct(ProductViewModel product)
        {
            var prod = context.Products.Find(product.Id) ?? new Product();
                       
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Category = product.Category;
            prod.Discount = product.Discount;
            prod.Price = product.Price;
          
            context.Products.Add(prod);

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

        public void EditProduct(string id, ProductViewModel product)
        {
            DeleteProduct(id);
            SaveProduct(product);            
        }

        private List<ProductViewModel> parse(List<Product> list)
        {
            var parsed = new List<ProductViewModel>();
            foreach (var c in list)            
                parsed.Add(new ProductViewModel(c));
            
            return parsed;
        }        
    }
}
