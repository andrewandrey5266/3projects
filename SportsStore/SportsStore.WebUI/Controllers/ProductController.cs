using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using SportsStore.Service.Services;
using SportsStore.ViewModel.Models;
using SportsStore.Service.Interfaces;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductService productServ;
        IReviewService reviewServ;
        public int PageSize =3;

        public ProductController(IProductService prodserv, IReviewService revserv)
        {
            productServ = prodserv;
            reviewServ = revserv;
        }

        public ViewResult List(string category = null, int page = 1)
        {
            
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = productServ.GetProducts(category, PageSize, page),
                PagingInfo = new PagingInfo(
                    page,
                    PageSize,
                    category == null ? productServ.GetProducts().Count : 2
                ),
                CurrentCategory = category
            };
            return View(model);
        }

        public ViewResult Detailed(string id)
        {
            DetailedProductViewModel model = new DetailedProductViewModel
            {
                Product = productServ.GetProduct(id),
                //Reviews = reviewServ.GetReviews(id)
            };
         
            return View(model);
        }

        public ViewResult Contacts()
        {
            return View();
        }

        
    }
}