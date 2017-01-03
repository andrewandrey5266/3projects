using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
namespace SportsStore.ViewModel.Models
{
    public class ReviewViewModel
    {
        public string Comment { get; set; }
        public int Score { get; set; }
        public string DateTime { get; set; }


        public string UserId { get; set; }
        public string ProductId { get; set; }

        public string UserName { get; set; }
 

        public ReviewViewModel(Review review)
        {
            this.Comment = review.Comment;
            this.Score = review.Score;
            this.DateTime = review.DateTime;
            this.UserName = review.User.Name;
            this.ProductId = review.Product.Id;
            this.UserId = review.Product.Id;

        }
    }
}
