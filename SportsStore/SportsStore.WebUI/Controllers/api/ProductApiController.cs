using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SportsStore.Service.Interfaces;
using SportsStore.ViewModel.Models;
using System.Linq;
using SportsStore.Service.Services;
namespace SportsStore.WebUI.Controllers
{
    public class ProductApiController : ApiController
    {
        private IProductService productServ = new ProductService();
        private IImageService imageServ = new ImageService();
        public int PageSize = 2;

       
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetProducts(string category, int page = 1)
        {
            var model = new ProductsListViewModel
            {
                Products = productServ.GetProducts(category, PageSize, page),
                PagingInfo = new PagingInfo(page, PageSize, productServ.GetProducts(category).Count),
                CurrentCategory = category
            };
             
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetProducts(string name,string category, int page = 1) // govnocode
        {
            var model = new ProductsListViewModel
            {

                Products = productServ.SearchProduct(name, category, PageSize, page),
                PagingInfo = new PagingInfo
                (
                   page, 
                   PageSize, 
                   productServ.GetProducts(category)        /////////// govnocode
                                .Where(i => i.Name.ToLower().Contains(name.ToLower()))
                                .ToList().Count
                ),
                CurrentCategory = category
            };
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }

        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetProductQuantity(string keyword)
        {
            int count = productServ.GetProducts()
                .Where(i => i.Name.ToLower().Contains(keyword.ToLower())).Count();


           // PageService ---->>>>>>
            return Request.CreateResponse(HttpStatusCode.OK, count);
        }
    }
}
