using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrashCollector.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

namespace TrashCollector.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext db;
        public CustomerController()
        {
            db = new ApplicationDbContext();
        }
        
        // GET: Customer
        public ActionResult Index()
        {
            var customers = db.Customers.Include(c => c.PickupDay).ToList();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = db.Customers.Include(c => c.PickupDay).SingleOrDefault(c => c.CustomerId == id);
            return View(customer);
        }

        // GET: Customer/Create
        public ActionResult CreateCustomer()
        {
            var pickupDays = db.PickupDays.ToList();
            Customer_PickupDayVM customerVM = new Customer_PickupDayVM
            {
                Customer = new Customer(),
                PickupDay = new PickupDay()
            };
            
            return View(customerVM);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here
                customer.ApplicationUserId = User.Identity.GetUserId();
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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
