using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CC9.Models;
namespace CC9.Controllers
{
    public class CodeController : Controller
    {
        readonly NorthwindEntities db = new NorthwindEntities();
        // GET: Code
        public ActionResult Index()
        {
            return View();
        }
        // 1. First action method should return all customers residing in Germany
        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }
        // 2. Second action method should return customer details with an orderId==10248
        public ActionResult CustomerByOrderId(int? orderId)
        {
            //if (orderId == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}

            //var customerDetails = db.Orders
            //                 .Where(o => o.OrderID == orderId)
            //                 .Select(o => o.Customer)
            //                 .FirstOrDefault();

            //if (customerDetails == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(customerDetails);
            var order = db.Orders.FirstOrDefault(o => o.OrderID == 10248);
            var customer = order?.Customer;
            return View(customer);
        }

    }
}