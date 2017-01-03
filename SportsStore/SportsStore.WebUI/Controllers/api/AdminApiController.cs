using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SportsStore.Domain.Entities;
using SportsStore.ViewModel.Models;
using SportsStore.Service.Interfaces;
using SportsStore.Service.Services;
namespace SportsStore.WebUI.Controllers
{
    public class AdminApiController : ApiController
    {
        IProductService prodServ = new ProductService();

        public AdminApiController() { }
     
        // GET api/adminapi
        public IEnumerable<ProductViewModel> Get()
        {
            var a = prodServ.GetProductsVM();

            return a;
        }

        // GET api/adminapi/5
        public ProductViewModel Get(string id)
        {
            return null;
        }

        // POST api/adminapi
        public void Post([FromBody]ProductViewModel value)
        {
            prodServ.SaveProduct(value);
        }

        // PUT api/adminapi/5
        public void Put(string id, [FromBody]ProductViewModel value)
        {
            
        }

        // DELETE api/adminapi/5
        public void Delete(string id)
        {
            prodServ.DeleteProduct(id);
        }
    }
}
