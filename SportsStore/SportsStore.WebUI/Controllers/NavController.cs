using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Context;
using SportsStore.Domain.Entities;
namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private IProductRepository repository;
        public NavController(IProductRepository repo)
        {
            repository = repo;
        }
        public PartialViewResult Menu()
        {
            // IEnumerable<string> categories = repository.Products
            //.Select(x => x.CategoryID)
            //.Distinct()
            //.OrderBy(x => x);
            IEnumerable<string> categories = repository.Categories.Select(x => x.Name);
             return PartialView(categories);
        }

    }
}
