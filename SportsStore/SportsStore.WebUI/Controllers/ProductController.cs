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
        private EFDbContext repository = new EFDbContext();
        private ProductService  productService = new ProductService();
  
        public int PageSize = 3;

        public ViewResult List(string category = null, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = productService.GetProduct(category, PageSize, page),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : 3
                },
                CurrentCategory = category
            };
            return View(model);
        }

    }
}