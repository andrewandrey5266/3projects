using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SportsStore.ViewModel.Models;
using SportsStore.Service.Interfaces;
using SportsStore.Service.Services;
namespace SportsStore.WebUI.Controllers
{
    public class ReviewApiController : ApiController
    {
        IReviewService reviewServ = new ReviewService();
        // GET api/reviewapi
        public IEnumerable<ReviewViewModel> Get()
        {
            return null;
        }

        // GET api/reviewapi/5
        public ReviewViewModel Get(int id)
        {
            return null;
        }

        // POST api/reviewapi
        public void Post([FromBody]ReviewViewModel value)
        {
        }

        // PUT api/reviewapi/5
        public void Put(int id, [FromBody]ReviewViewModel value)
        {
        }

        // DELETE api/reviewapi/5
        public void Delete(int id)
        {
        }
    }
}
