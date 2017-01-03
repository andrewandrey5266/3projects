using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SportsStore.Service.Interfaces;
using SportsStore.ViewModel.Models;
using SportsStore.Service.Services;

namespace SportsStore.WebUI.Controllers.api
{
    public class WishListApiController : ApiController
    {
        IWishListService wishServ = new WishListService();

        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetWishes(string userId)
        {
            var model = new WishListViewModel
            {
                Wishes = wishServ.GetWishes(userId)
            };
            
            return Request.CreateResponse(HttpStatusCode.OK,model);
        }

        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> PostWish(string productid, string userid)
        {
            wishServ.AddWish(productid, userid);
            return Request.CreateResponse(HttpStatusCode.OK, new { });
        }
    }
}
