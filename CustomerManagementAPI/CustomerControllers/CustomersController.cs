using BusinessObject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using System;

namespace CustomerManagementAPI.CustomerControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerRepository customerRepo = new CustomerRepository();

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetCustomers() => customerRepo.GetAll();

        [HttpGet("name")]
        public ActionResult<Customer> GetCustomerByUsername(string name) => customerRepo.GetCustomerByName(name);


        [HttpPost]
        public IActionResult PostCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("Customer cannot be null !!");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            customerRepo.AddCustomer(customer);
            return NoContent();
        }

        [HttpDelete("name")]
        public IActionResult DeleteCustomer(string name)
        {
            var c = customerRepo.GetCustomerByName(name);
            if (c == null)
            {
                return NotFound("Customer not found");
            }
            customerRepo.DeleteCustomer(c);
            return NoContent();
        }

        [HttpPut("name")]
        public IActionResult PutCustomer(string name, [FromBody] Customer customer)
        {
            var c = customerRepo.GetCustomerByName(name);
            if (c == null)
            {
                return BadRequest("No Customer found !!");
            }
            customerRepo.UpdateCustomer(customer);
            return NoContent();
        }
    }
}
