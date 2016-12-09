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
                Products = repository.Products
                .Where(p => category == null || p.Category.Name == category)
                .OrderBy(p => p.Id)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null? repository.Products.Count():3
                    //category == null? repository.Products.Count() :                   
                    //    repository.Categories.Where(c => c.Name == category).Select(s => s.Products).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }

    }
}