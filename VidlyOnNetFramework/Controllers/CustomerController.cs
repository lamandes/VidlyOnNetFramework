using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyOnNetFramework.Models;

namespace VidlyOnNetFramework.Controllers
{
    public class CustomerController : Controller
    {
        //Get from database
        private ApplicationDbContext  _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //Add new customer
        // Get: Customer/New/
        //[Route("Customer/New")]
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        //Post Form to create account
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //Add validation if invalid return original view
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()

                };

                return View("CustomerForm", viewModel);
            }

            //From New
            if (customer.ID == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var existingCustomer = _context.Customers.Single(c => c.ID == customer.ID);
                //TryUpdateModel(existingCustomer)
                //Mapper.Map(customer, existingCustomer);

                existingCustomer.Name = customer.Name;

            }
            _context.SaveChanges();

            return RedirectToAction("Customer", "Customer");
        }
        [Route("Customer/Edit/{id}")]
        // Edit Customer/Edit/
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
        }

        [Route("Customer")]
        // GET: Customer
        public ActionResult Customer()
        {
            var customerList = _context.Customers.Include(c=> c.MembershipType).ToList();

            var viewModel = new CustomerViewModel
            {
                CustomerList = customerList
            };
            return View(viewModel);
        }

        
        

        [Route("Customer/Detail/{id}")]

        // GET: Customer/Detail/xxxx
        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.ID == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(customer);
            }
        }
    }
}