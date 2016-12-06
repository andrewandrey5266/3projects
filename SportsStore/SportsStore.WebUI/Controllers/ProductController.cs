using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Context;
using SportsStore.WebUI.Models;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 3;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        //public ViewResult List()
        //{
        //    return View(repository.Products);
        //}
        //public ViewResult List(int page = 1)
        //{
        //    return View(repository.Products
        //    .OrderBy(p => p.ProductID)
        //    .Skip((page - 1) * PageSize)
        //    .Take(PageSize));
        //}
        public ViewResult List(string category = null, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products
                .Where(p => category == null || p.category.Name == category)
                .OrderBy(p => p.ProductID)
                .Skip((page - 1) * PageSize)
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null? repository.Products.Count() :                   
                        repository.Categories.Where(c => c.Name == category).Select(s => s.Products).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        } //p.CategoryID == 
        //repository.Categories.Where(i => i.Name == category).FirstOrDefault().CategoryID)

    }
}