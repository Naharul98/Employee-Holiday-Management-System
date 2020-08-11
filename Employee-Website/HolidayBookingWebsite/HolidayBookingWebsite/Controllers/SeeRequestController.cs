using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayBookingWebsite.Controllers
{
    public class SeeRequestController : Controller
    {
        // GET: SeeRequest
        //This method is called when the user requests to see status of his requested holiday
        public ActionResult Index()
        {
            //instantiate empty list of data to send to views
            List<HolidayRequest> requestList = new List<HolidayRequest>();
            //get id of logged in user from the cookie
            var employeeID = Int32.Parse(Request.Cookies["employeeIdCookie"].Value.Split('=')[1].ToString());
            //using entity framework to query database
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //query database to get all holidays requested by the user
                var holidayRequests = context.HolidayRequests.Where(emp => emp.Employee.Id == employeeID).Select(e => new { e.Employee.name, e.date_from, e.date_to, e.reason, e.approval }).ToList();

                //for each query result
                int index = 0;
                while(index< holidayRequests.Count)
                {
                    //get the query result row
                    var request = holidayRequests[index];
                    //create holiday request object containing data of the request
                    HolidayRequest req = new HolidayRequest();
                    req.date_from = request.date_from;
                    req.date_to = request.date_to;
                    req.reason = request.reason;
                    req.approval = request.approval;
                    //add object to list
                    requestList.Add(req);

                    index = index + 1;
                }

            }
            //return view containing data to display
            return View(requestList);
        }
    }
}