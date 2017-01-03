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
    public class DiscountApiController : ApiController
    {
        IDiscountService categServ = new DiscountService();
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetDiscounts()
        {
            var model = categServ.GetDiscounts().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }
    }
}
