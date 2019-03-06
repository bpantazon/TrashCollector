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
        private ApplicationDbContext db;
        //IList<Customer> customerList = new List<Customer>() { };
        //IList<Customer> employeesCustomers = new List<Customer>() { };
        public EmployeeController()
        {
            db = new ApplicationDbContext();
        }
        
        // GET: Employee
        //get customers from the database for the employee to view
        public ActionResult Index(Employee employee)
        {
            try
            {
                db.Customers.ToList();
                foreach (var cust in db.Customers)
                {
                    //List<Customer> employeesCustomers = db.Customers.Where(c => c.Zip == employee.PickupZip);
                    //var customer = db.Customers.Where(c => c.Zip == employee.PickupZip);

                    //customerList.Add(cust); //add all customers to a list
                }

                //try to filter customers that match the employees zip code to a new list that will show to the employee
                //customerList.Add(customer);



            }
            catch
            {
                return View();
            }
            return View(/*customerList*/);
        }
    }
}