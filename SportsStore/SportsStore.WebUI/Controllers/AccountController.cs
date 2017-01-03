using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.ViewModel.Models;
using SportsStore.WebUI.Models;
using SportsStore.Service.Interfaces;
using SportsStore.Service.Services;
namespace SportsStore.WebUI.Controllers
{
    public class AccountController : Controller
    {
        IAuthProvider authProvider;
        IUserService userServ;
        public AccountController(IAuthProvider auth, IUserService userServ)
        {
            authProvider = auth;
            this.userServ = userServ;
        }
        public ViewResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            Session["Auth"] = null;
            Session["Cart"] = null;
            return RedirectToAction("List", "Product");
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = userServ.Authenticate(model.Logname, model.Password);
                if (user != null)
                {
                    //return Redirect(Url.Action("Index", "Admin"));
                    Session["Auth"] = user;
                    return Redirect("/");
                }
                if (user == null)
                {
                    ModelState.AddModelError("", "Incorrect username or password");
                    return View();
                }
               
                else return View("Error");
                
            }
            else
            {
                return View();
            }
        }

        public ViewResult Register()
        {
            return View(new ProfileViewModel());
        }

        [HttpPost]
        public ActionResult Register(ProfileViewModel registryVM)
        {
            if (ModelState.IsValid)
            {
                string result = userServ.Register(registryVM);
              
                if (result == "success")
                    return RedirectToAction("List", "Product");
                if (result == "email error")
                {
                    ModelState.AddModelError("Email", "User with this email already exists");
                    registryVM.Email = "";
                    return View(registryVM);
                }
                if (result == "logname error")
                {
                    ModelState.AddModelError("Logname", "User with this logname already exists");
                    registryVM.Logname = "";
                    return View(registryVM);
                }

                else return View("Error");
                
            }
            else
            {
                return View(new ProfileViewModel());
            }
        }

        public ViewResult MyProfile()
        {
            var user = (UserViewModel)Session["Auth"];
            user.wishes = new WishListViewModel(new WishListService().GetWishes(user.Id));
            Session["Auth"] = user;
            return View((UserViewModel)Session["Auth"]);
        }
    }
}
