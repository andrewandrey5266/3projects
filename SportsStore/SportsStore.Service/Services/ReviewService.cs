using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Service.Interfaces;
using SportsStore.Domain.Entities;
using SportsStore.Context;
namespace SportsStore.Service.Services
{
    public class ReviewService : IReviewService
    {
        EFDbContext context = new EFDbContext();
        public List<Review> GetReviews(string productId)
        {
            return context.Reviews
                .Include("Product")
                .Include("User")
                .Where(i => i.Product.Id == productId)
                .ToList();
        }


        public bool AddReview(Review review)
        {
            //hard code ( because User in UserViewModel is stored only partially, and we need to find it 
            review.User = context.Users
                .Where(i => i.Id == review.User.Id)
                .FirstOrDefault();

            review.Product = context.Products
                .Where(i => i.Id == review.Product.Id)
                .FirstOrDefault();

            review.DateTime = DateTime.Now.ToString();

            context.Reviews.Add(review);
            context.SaveChanges();
            return true;
        }
    }
}
