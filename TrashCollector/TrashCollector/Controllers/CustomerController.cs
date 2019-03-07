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
            var customers = db.Customers.ToList();
            return View(customers);
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {

            Customer_PickupDayVM customerVM = new Customer_PickupDayVM
            {
                Customer = db.Customers.Where(c => c.CustomerId == id).FirstOrDefault()
            };
            
            return View(customerVM);
        }

        // GET: Customer/Create
        public ActionResult CreateCustomer()
        {
            //var pickupDays = db.PickupDays.ToList();
           
            Customer_PickupDayVM customerVM = new Customer_PickupDayVM
            {
                Customer = new Customer(),
                //PickupDaysList = new SelectList(pickupDays)
                //PickupDay = new PickupDay()
            };
            
            return View(customerVM);
        }

        // POST: Customer/Create
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
                // TODO: Add insert logic here    
            try
            {
                customer.ExtraPickup = null;
                customer.SuspendStart = null;
                customer.SuspendEnd = null;
                db.Customers.Add(customer);
                customer.ApplicationUserId = User.Identity.GetUserId();
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
            var customer = db.Customers.Where(c => c.CustomerId == id).FirstOrDefault();
            return View(customer);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
                var updatedCustomer = db.Customers.Where(c => c.CustomerId == id).Single();

                updatedCustomer.FirstName = customer.FirstName;
                updatedCustomer.LastName = customer.LastName;
                updatedCustomer.DayForPickup = customer.DayForPickup;
                updatedCustomer.ExtraPickup = customer.ExtraPickup;
                updatedCustomer.SuspendStart = customer.SuspendStart;
                updatedCustomer.SuspendEnd = customer.SuspendEnd;

                db.SaveChanges();
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
