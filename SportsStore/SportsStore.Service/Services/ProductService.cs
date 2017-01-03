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

        public List<Product> GetProducts(string category, int pageSize, int page)
        {
            if (category == "all") category = null;

           
                List<Product> c = context.Products
                  .Include("Discount")
                  .Where(p => category == null || p.Category.Name == category)
                  .OrderBy(p => p.Id)
                  .Skip((page - 1) * pageSize)
                  .Take(pageSize).ToList();

            return c;
        }
        public List<Product> GetProducts(string category)
        {
            if (category == "all") category = null;
            return context.Products
                  .Include("Category")
                  .Include("Discount")
                  .Where(p => category == null || p.Category.Name == category)         
                  .ToList();
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
            return GetProducts().Where(i => i.Id == id).FirstOrDefault();
        }
        public void SaveProduct(ProductViewModel product)
        {
            var prod = context.Products.Find(product.Id);
            if (prod == null)
            {
                prod = new Product();
                context.Products.Add(prod);
            }
            prod.Name = product.Name;
            prod.Description = product.Description;
            prod.Category = context.Categories
                .Where(i => i.Name == product.CategoryName)
                .FirstOrDefault();
            prod.Discount = context.Discounts
                .Where(i=> i.Percentage == product.DiscountPercentage)
                .FirstOrDefault();
            prod.Price = product.Price;
            prod.InStock = product.InStock;
      
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

        public List<Product> SearchProduct(string name, string category, int pageSize, int page)
        {
            //var a = GetProducts(category, pageSize, page);
            //var b = a.Where(i => i.Name.ToLower().Contains(name.ToLower()))
            //    .ToList();

            //return b;
            return GetProducts(category)
                .Where(i => i.Name.ToLower().Contains(name.ToLower()))
                .ToList()
                .OrderBy(i => i.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize).ToList();
        }


      
    }
}
