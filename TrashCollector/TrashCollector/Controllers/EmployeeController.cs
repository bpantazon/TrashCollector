using Microsoft.AspNet.Identity;
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
        public EmployeeController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Employee
        public ActionResult EmployeeIndex()
        {
            var user = User.Identity.GetUserId();
            var emp = db.Employees.Where(s => s.ApplicationUserId == user).Single();
            DayOfWeek today = DateTime.Today.DayOfWeek;
            var currentDate = DateTime.Today;
            var customers = db.Customers.Where(c => c.Zip == emp.PickupZip && c.DayForPickup == today.ToString()).ToList();
 
            return View(customers);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: Employee/Create
        public ActionResult CreateEmployee()
        {
            Employee employee = new Employee();
          
            return View(employee);
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee)
        {
            try
            {
                // TODO: Add insert logic here              
                db.Employees.Add(employee);
                employee.ApplicationUserId = User.Identity.GetUserId();
                db.SaveChanges();
                return RedirectToAction("EmployeeIndex");
            }
            catch
            {
                return View();  
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var editedCustomer = db.Customers.Where(c => c.CustomerId == id).SingleOrDefault();
                return View(editedCustomer);
            }
            catch
            {
                return View();
            }
           
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var editedCustomer = db.Customers.Where(c => c.CustomerId == id).SingleOrDefault();
                editedCustomer.PickupConfirmed = customer.PickupConfirmed;
                if (editedCustomer.PickupConfirmed == true)
                {
                    editedCustomer.Balance = editedCustomer.Balance + 25.00m;                    
                }
                
                editedCustomer.ExtraPickupConfirmed = customer.ExtraPickupConfirmed;
                if (editedCustomer.ExtraPickupConfirmed == true)
                {
                    editedCustomer.Balance = editedCustomer.Balance + 20.00m;                   
                }
                editedCustomer.PickupConfirmed = false;
                editedCustomer.ExtraPickupConfirmed = false;
                db.SaveChanges();
                
                
                //db.SaveChanges();
                return RedirectToAction("EmployeeIndex");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Monday
        public ActionResult Monday()
        {
            try
            {

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
