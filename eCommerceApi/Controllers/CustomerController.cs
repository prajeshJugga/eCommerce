using eCommerceApi.Exceptions;
using eCommerceApi.Responses;
using eCommerceApi.Services;
using eCommerceDatabase.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly ICustomerService _customerService;

        public CustomerController(ILogger<CustomerController> logger, ICustomerService customerService)
        {
            _logger = logger;
            _customerService = customerService;
        }

        //[HttpGet( Name = "GetCustomerById")]
        [HttpGet("{customerId}")]
        public ActionResult<Response<CustomerDTO>> GetCustomerById(int customerId)
        {
            try
            {
                CustomerDTO customerDTO = _customerService.GetCustomerById(customerId);
                return new Response<CustomerDTO>(customerDTO);
            }
            catch (CustomerNotFoundException)
            {
                return NotFound();
            }
            catch
            {
                return StatusCode(500);
            }

        }
    }
}
