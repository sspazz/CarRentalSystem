using CarRentalSystem.Interfaces;
using CarRentalSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CarRentalSystem.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _customerService.GetAllCustomers();
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> Get(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return NotFound();

            return customer;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Customer customer)
        {
            _customerService.AddCustomer(customer);
            return Ok();
        }

        [HttpPut]
        public ActionResult Put([FromBody] Customer customer)
        {
            _customerService.UpdateCustomer(customer);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _customerService.DeleteCustomer(id);
            return Ok();
        }
    }
}
