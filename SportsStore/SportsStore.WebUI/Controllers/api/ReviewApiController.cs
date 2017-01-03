using SportsStore.Service.Interfaces;
using SportsStore.Service.Services;
using SportsStore.ViewModel.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net;
namespace SportsStore.WebUI.Controllers
{
    public class ReviewApiController : ApiController
    {
        IReviewService reviewServ = new ReviewService();
     
        [System.Web.Http.HttpGet]
        public async Task<HttpResponseMessage> GetReviews(string productId)
        {
            var model = reviewServ.GetReviews(productId);
            return Request.CreateResponse(HttpStatusCode.OK, model);
        }


        [System.Web.Http.HttpPost]
        public async Task<HttpResponseMessage> PostReview(ReviewViewModel review)
        {
            return null;
        }
    }
}
