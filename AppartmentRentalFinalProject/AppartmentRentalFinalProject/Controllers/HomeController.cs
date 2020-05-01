using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppartmentRentalFinalProject.Models;

namespace AppartmentRentalFinalProject.Controllers
{
    public class HomeController : Controller
    {

      PropertyRentalManagementDBEntities db = new PropertyRentalManagementDBEntities();
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult getUserList()
        {
            var user = db.Users.ToList();
            return View(user);
        }
        //[Authorize(Roles ="Admin, Customer")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}