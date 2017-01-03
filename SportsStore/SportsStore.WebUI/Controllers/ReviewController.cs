using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Service.Services;
using SportsStore.Service.Interfaces;
namespace SportsStore.WebUI.Controllers
{
    public class ReviewController : Controller
    {
        IReviewService reviewServ;
        public ReviewController(IReviewService revServ)
        {
            reviewServ = revServ;
        }

        public ViewResult Edit(string id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Review review, string ProductId, string UserId)
        {
            review.Product = new Product{ Id = ProductId };
            review.User = new User{ Id = UserId };
            if (ModelState.IsValid)
            {
                //reviewServ.AddReview(review);

                return RedirectToAction("Detailed", "Product", new { Id = ProductId });
            }
            else
            {
                // there is something wrong with the data values
                return View("error");
            }
        }

    }
}
