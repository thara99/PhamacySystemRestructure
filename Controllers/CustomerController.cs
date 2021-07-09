using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhamacySystemRestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhamacySystemRestructure.Model;

namespace PhamacySystemRestructure.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private ICustomerRepository _customers;

        public CustomerController(ICustomerRepository customers)
        {
            _customers = customers;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetCustomers()
        {
            return Ok(_customers.GetCustomers());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetCustomer(int id)
        {
            var customers = _customers.GetCustomer(id);

            if (customers != null)
            {
                return Ok(_customers.GetCustomer(id));
            }
            return NotFound($"Customer with ID: {id} was not found");
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddMedicine(Customer customers)
        {
            _customers.AddCustomer(customers);

            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
                customers.CId, customers);
        }

        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public IActionResult DeleteCustomer(int id)
        {
            var customers = _customers.GetCustomer(id);

            if (customers != null)
            {
                _customers.DeleteCustomer(customers);
                return Ok();

            }
            return NotFound($"Customer with ID: {id} was not found");

        }

        [HttpPatch]
        [Route("api/[controller]/{id}")]
        public IActionResult EditCustomer(int id, Customer customers)
        {
            var exixtingCustomer = _customers.GetCustomer(id);

            if (exixtingCustomer != null)
            {
                customers.CId = exixtingCustomer.CId;
                _customers.EditCustomer(customers);

            }
            return Ok(customers);

        }

    }
}
