using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        IList<Customer> customerList = new List<Customer>() { };
        public EmployeeController()
        {
            db = new ApplicationDbContext();
        }
        ApplicationDbContext db;
        // GET: Employee
        //get customers from the database for the employee to view
        public ActionResult Index()
        {
            try
            {
                db.Customers.ToList();
            }
            catch
            {
                return View();
            }
            return View(customerList);
        }
    }
}