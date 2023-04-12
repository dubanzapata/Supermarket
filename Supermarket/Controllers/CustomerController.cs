using Microsoft.AspNetCore.Mvc;
using Supermarket.Contrats.Interfaces.Services;
using Supermarket.Core.Services;
using Supermarket.Dto.Request;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Supermarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService= customerService;

        }
       

        // GET: api/<CustomerController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customer= await _customerService.GetCustomers();
            return Ok(customer);
            
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer= await _customerService.GetCustomerById(id);   
            return Ok(customer);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public async Task<IActionResult> Post(CustomerRequest addCustomer)
        {
            var customer = await _customerService.AddCustomer(addCustomer);
            return Ok(customer);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id,CustomerRequest UpdateCustomer)
        {
            var customer= await _customerService.UpdateCustomer(id,UpdateCustomer);
            return Ok(customer);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer= await _customerService.DeleteCustomer(id);
            return Ok(customer);
        }
    }
}
