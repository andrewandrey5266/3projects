using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.ViewModel.Models;
namespace SportsStore.Service.Interfaces
{
    public interface IProductService
    {
       List<Product> GetProducts(string category, int pageSize, int page);

       List<Product> GetProducts(string category);

       List<Product> GetProducts();

       List<Product> SearchProduct(string name, string category, int pageSize, int page);

       IEnumerable<ProductViewModel> GetProductsVM();
 
       Product GetProduct(string id);

       void SaveProduct(ProductViewModel product);

       Product DeleteProduct(string productId);

      void EditProduct(string id, ProductViewModel product);

    }
}
