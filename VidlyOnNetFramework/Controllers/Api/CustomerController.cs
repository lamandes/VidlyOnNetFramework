using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VidlyOnNetFramework.Dtos;
using VidlyOnNetFramework.Models;

namespace VidlyOnNetFramework.Controllers.Api
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        //GET /api/customers
        /*
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }*/
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);
        }

        //GET /api/customers/1 as example
        public CustomerDto GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(m => m.ID == id);
            
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            //return customer;
            //Dto
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //POST /api/customer
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                //original ActionResult
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                //IHttpActionResult
                return BadRequest();
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            try
            {
                _context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine(e);
            }

            customerDto.ID = customer.ID;

            //Return URI /api/customer/{customerDto.ID}
            return Created(new Uri(Request.RequestUri + "/" + customer.ID), customerDto);
        }

        [HttpPut]
        //PUT /api/customer/1
        public void UpateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var existingCustomer = _context.Customers.SingleOrDefault(c => c.ID == customerDto.ID);
            if (existingCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, existingCustomer);

            //Changes are mapped to db properties
            //existingCustomer.Name = customerDto.Name;
            //existingCustomer.MembershipTypeId = customerDto.MembershipTypeId;
            //existingCustomer.BirthDate = customerDto.BirthDate;
            //existingCustomer.IsSubscribedToNewsletter = customerDto.IsSubscribedToNewsletter;

            //Save change to db
            _context.SaveChanges();
        }

        [HttpDelete]
        //DELETE /api/customer/1
        public void DeleteCustomer(int id, Customer customer)
        {
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.ID == id);
            if (existingCustomer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();
        }
    }
}
