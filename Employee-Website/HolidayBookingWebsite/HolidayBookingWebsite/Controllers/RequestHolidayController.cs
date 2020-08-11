using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HolidayBookingWebsite.Controllers
{
    [Authorize]
    public class RequestHolidayController : ApiController
    {
        // GET: api/RequestHoliday
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RequestHoliday/5
        public string Get(int id)
        {
            return "value";
        }

        [Route("api/requestholiday/AttemptRequest/{dateFrom}/{dateTo}/{reason}/{employeeID}")]
        [AllowAnonymous]
        [System.Web.Http.HttpGet]
        public IHttpActionResult AttemptRequest(string dateFrom, string dateTo, string reason, string employeeID)
        {
            
            using (holiday_dbEntities context = new holiday_dbEntities())
            {
                //creating the holiday request record to add to the database
                HolidayRequest requestToAdd = new HolidayRequest
                {
                    employee_id = Int32.Parse(employeeID),
                    reason = reason,
                    date_from = DateTime.Parse(dateFrom),
                    date_to = DateTime.Parse(dateTo),
                };
                //add the created record to holiday request database table
                context.HolidayRequests.Add(requestToAdd);
                //save changes in database
                context.SaveChanges();
                //redirect to success page of the website
                return Ok("OK");
            }
        }

        // POST: api/RequestHoliday
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RequestHoliday/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RequestHoliday/5
        public void Delete(int id)
        {
        }
    }
}
