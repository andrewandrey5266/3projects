using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Service.Interfaces;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using SportsStore.ViewModel.Models;

namespace SportsStore.Service.Services
{
    public class ReviewService : IReviewService
    {
        EFDbContext context = new EFDbContext();
        public List<ReviewViewModel> GetReviews(string productId)
        {
            var reviews = context.Reviews
                .Include("Product")
                .Include("User")
                .Where(i => i.Product.Id == productId)
                .ToList();

            var response = new List<ReviewViewModel>();
            foreach (var c in reviews)
                response.Add(new ReviewViewModel(c));


            return response;
        }


        public bool AddReview(ReviewViewModel review)
        {
     
            review.DateTime = DateTime.Now.ToString();

            context.Reviews.Add(new Review
            {
                Comment = review.Comment,
                Score = review.Score,
                DateTime = DateTime.Now.ToString(),
                User = context.Users.Where(i => i.Id == review.UserId).FirstOrDefault(),
                Product = context.Products.Where(i=> i.Id == review.ProductId).FirstOrDefault()
            });
            context.SaveChanges();
            return true;
        }
    }
}
