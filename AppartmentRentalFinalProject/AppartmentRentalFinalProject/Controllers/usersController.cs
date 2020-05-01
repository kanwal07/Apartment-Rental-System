using AppartmentRentalFinalProject.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppartmentRentalFinalProject.Controllers
{
    [Authorize]

    public class usersController : Controller
    {
        // GET: users
        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";


                if (isAdminUser())
                {
                    ViewBag.displayMenu = "yes";
                }

                return View();

            }
            else 
            {
                ViewBag.Name = "not logged in";
            }
            return View();
        }

        private bool isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[1].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            return false;
        }
    }



   
}