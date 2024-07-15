using eCommerceApi.Responses;
using eCommerceApi.Services;
using eCommerceDatabase.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet(Name = "GetProducts")]
        public ActionResult<Response<List<ProductDTO>>> GetProducts()
        {
            try
            {
                List<ProductDTO> productDTOs = _productService.GetProducts();
                return new Response<List<ProductDTO>>(productDTOs);
            }
            catch (ArgumentNullException)
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
