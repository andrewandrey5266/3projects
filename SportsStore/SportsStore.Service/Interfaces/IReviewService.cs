﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStore.Domain.Entities;
using SportsStore.ViewModel.Models;
namespace SportsStore.Service.Interfaces
{
    public interface IReviewService
    {
       List<ReviewViewModel> GetReviews(string productId);

       bool AddReview(ReviewViewModel review);
    }
}
