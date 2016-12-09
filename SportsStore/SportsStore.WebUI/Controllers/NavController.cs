using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Entities;
using SportsStore.Context;
using SportsStore.Service.Services;


namespace SportsStore.WebUI.Controllers
{
    public class NavController : Controller
    {
        private EFDbContext repository = new EFDbContext();

        public PartialViewResult Menu(string category = null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> categories = repository.Categories.Select(x => x.Name);
             return PartialView(categories);
        }

    }
}
