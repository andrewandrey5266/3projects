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
       IEnumerable<Product> GetProduct(string category, int PageSize, int page);

       List<Product> GetProducts();

       Product GetProduct(string id);

       void SaveProduct(ProductViewModel product);

       Product DeleteProduct(string productId);

      void EditProduct(string id, ProductViewModel product);


      IEnumerable<ProductViewModel> GetProductsVM();
    }
}
