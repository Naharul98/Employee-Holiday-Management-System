using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HolidayBookingWebsite.Controllers
{
    //The controller class implements logic for logging in to the website
    public class LoginController : Controller
    {
        //This method shows the login page of the website with its form
        public ActionResult Index()
        {
            return View();
        }

        //this method is reponsible for logging the user out of the website
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();//signs the user out
            HttpCookie cookie = Request.Cookies["employeeIdCookie"];//getting the logged in website cookie
            cookie.Expires = DateTime.Now.AddDays(-1);//Sets the logged in user cookie to expired as the person has logged out
            Response.Cookies.Add(cookie);//updates the logged in user cookie

            //clears and abandons the previous session as the user has logged out
            Session.Clear();
            Session.Abandon();
            //redirects user back to the login page as the user has logged out
            return Redirect("/login");
        }

        //This method is responsible for the logic behind the user login
        //It facilitates login and also checks for invalid login credentials
        [HttpPost]
        public ActionResult Index(string username, string password)
        {
                //using the database model
                using (holiday_dbEntities context = new holiday_dbEntities())
                {
                    //query the database and check that if an employee indeed exists in the database with the posted login credentials in the form
                    var record = context.Employees.Where(emp => emp.email == username).Where(emp => emp.password == password).Where(emp => emp.Role.role_name != "admin");
                    //If an employee with login credentials posted in the form exists and is not an admin
                    if (record.Count() > 0)
                    {
                        //Mark the system as logged in using authentication cookie
                        FormsAuthentication.SetAuthCookie(username, false);
                        
                        //create user logged in cookie
                        HttpCookie employeeIdCookie = new HttpCookie("employeeIdCookie");
                        //Set the Cookie value to the id of the user logged in
                        employeeIdCookie.Values["ID"] = record.First().Id.ToString();
                        //Add the Cookie to Browser.
                        Response.Cookies.Add(employeeIdCookie);
                        //redirect user to the home page after login
                        return Redirect("/");
                    }
                }

            return View();
        }


    }
}