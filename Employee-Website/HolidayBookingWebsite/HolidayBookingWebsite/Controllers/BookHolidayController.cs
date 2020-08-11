using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayBookingWebsite.Controllers
{
    //The controller class which implements logic for Requesting holiday booking
    [Authorize]
    public class BookHolidayController : Controller
    {
        // shows the index page in book holiday view
        public ActionResult Index()
        {
            return View();
        }

        // shows the success page after holiday book request has been successful
        [Route("success")]
        public ActionResult Success()
        {
            return View("Success");
        }

        //This method is responsible for validating holiday book request data posted in form
        //In addition, it is responsible for adding holiday request data in the database
        [Route("makebooking/{employeeID}")]
        [HttpPost]
        public ActionResult MakeBooking(string employeeID)
        {
            int idOfEmployee = 0;
            try
            {
                idOfEmployee = Int32.Parse(employeeID); // this variable holds the id of the employee making the request
                var purpose = Request.Form["reason"].ToString(); // the reason for holiday as posted from the booking form
                var dt_from = DateTime.Parse(Request.Form["date_from"]); // the starting date of request as posted from booking form
                var dt_to = DateTime.Parse(Request.Form["date_to"]); // the end date of request as posted from booking form

                // check that holiday end date is not of a earlier date than start as that would make request invalid
                if (dt_from<=dt_to) 
                {
                    //using the database entity model
                    using (holiday_dbEntities context = new holiday_dbEntities())
                    {
                        //creating the holiday request record to add to the database
                        HolidayRequest requestToAdd = new HolidayRequest
                        {
                            employee_id = idOfEmployee,
                            reason = purpose,
                            date_from = dt_from,
                            date_to = dt_to,
                        };
                        //add the created record to holiday request database table
                        context.HolidayRequests.Add(requestToAdd);
                        //save changes in database
                        context.SaveChanges();
                        //redirect to success page of the website
                        return Redirect("/success");
                    }
                }
            }
            catch (Exception e){}

            return View();
        }

    }
}