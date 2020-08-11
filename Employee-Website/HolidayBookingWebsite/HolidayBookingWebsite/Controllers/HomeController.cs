using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayBookingWebsite.Controllers
{

    //this controller class represents the model which is responsible for the home page of the website
    [Authorize]
    public class HomeController : Controller
    {
        //shows the home page of the website
        public ActionResult Index()
        {
            return View();
        }

    }
}