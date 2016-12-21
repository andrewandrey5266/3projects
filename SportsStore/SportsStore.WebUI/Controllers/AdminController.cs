using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Service.Interfaces;
using SportsStore.ViewModel.Models;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Controllers
{
  
    public class AdminController : Controller
    {
        public IProductService productServ;
        ICategoryService categoryServ;
        public AdminController(IProductService prodServ, ICategoryService categoryServ)
        {
            productServ = prodServ;
            this.categoryServ = categoryServ;
        }
        public ViewResult Index()
        {
            var temp = new ProductsListViewModel
            {
                Products = productServ.GetProducts()
            };
            return View(temp);
        }
                
        public ViewResult Edit(string Id)
        {
            var categories = new List<string>();
            categories.AddRange(categoryServ.GetCategories());
            ViewBag.Categories = categories;

            ProductViewModel product = productServ.GetProductsVM()
            .FirstOrDefault(p => p.Id == Id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                productServ.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                // there is something wrong with the data values
                return View(product);
            }
        }

        public ViewResult Create()
        {
            var categories = new List<string>();
            categories.AddRange(categoryServ.GetCategories());
            ViewBag.Categories = categories;

            return View("Edit", new ProductViewModel());
        }

        [HttpPost]
        public ActionResult Delete(string productId)
        {
            Product deletedProduct = productServ.DeleteProduct(productId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedProduct.Name);
            }
            return RedirectToAction("Index");
        }
    }
}
