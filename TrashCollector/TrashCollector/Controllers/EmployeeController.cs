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
        public ActionResult Index(int id)
        {
            Employee_CustomerVM employeeVM = new Employee_CustomerVM
            {
                CurrentEmployee = db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault(),
                Customer = db.Customers.Where(c => c.Zip == db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault().PickupZip).FirstOrDefault()
            };
            return View(employeeVM);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            Employee_CustomerVM employeeVM = new Employee_CustomerVM
            {
                CurrentEmployee = db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault(),
                Customer = db.Customers.Where(c => c.Zip == db.Employees.Where(e => e.EmployeeId == id).FirstOrDefault().PickupZip).FirstOrDefault()
            };
            return View(employeeVM);
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
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
    }
}
