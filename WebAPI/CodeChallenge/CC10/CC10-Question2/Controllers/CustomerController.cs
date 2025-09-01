using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CC10_Question2.Models;
namespace CC10_Question2.Controllers
{
    public class CustomerController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();
        [HttpGet]
        [Route("getCustomersByCountry")]
        public IHttpActionResult GetCustomersByCountry(string country)
        {
            var countryList = db.GetCustomersByCountry(country);
            if (countryList == null || countryList.Count() == 0)
                return NotFound();
            return Ok(countryList);
        }

        [HttpGet]
        [Route("getOrdersById")]
        public IHttpActionResult GetOrders(int empId)
        {
            var orders = db.Orders.Where(o => o.EmployeeID == empId);
            if (orders == null || orders.Count() == 0)
                return NotFound();
            return Ok(orders);
        }
    }
}
