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
    [Authorize]
    public class AdminController : Controller
    {
        public IProductService productServ;
        public AdminController(IProductService prodServ)
        {
            productServ = prodServ;
        }
        public ViewResult Index()
        {
            var temp = new ProductsListViewModel
            {
                Products = productServ.GetProduct()
            };
            return View(temp);
        }

        public ViewResult Edit(string Id)
        {
            Product product = productServ.GetProduct()
            .FirstOrDefault(p => p.Id == Id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
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
            return View("Edit", new Product());
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
