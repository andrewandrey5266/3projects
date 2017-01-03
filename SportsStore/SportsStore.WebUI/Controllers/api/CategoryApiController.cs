using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SportsStore.Service.Interfaces;
using SportsStore.ViewModel.Models;
using SportsStore.Service.Services;
using System.Linq;
namespace SportsStore.WebUI.Controllers.api
{
    public class CategoryApiController : ApiController
    {
        ICategoryService categServ = new CategoryService();
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetCategories()
        {
            var model = categServ.GetCategories().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}
