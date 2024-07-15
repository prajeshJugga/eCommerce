using eCommerceApi.Responses;
using eCommerceApi.Services;
using eCommerceDatabase.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace eCommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BasketController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILogger<BasketController> _logger;

        public BasketController(ILogger<BasketController> logger,
            IBasketService basketService)
        {
            _logger = logger;
            _basketService = basketService;
        }

        [HttpPut("{customerId}/{activeSpecialId}")]
        public async Task<ActionResult<Response<BasketDTO>>> AddBasketItem(BasketItemDTO bucketItem, int customerId, int activeSpecialId)
        {
            try
            {
                BasketDTO basket = await _basketService.AddBasketItem(bucketItem, customerId, activeSpecialId);
                return Ok(new Response<BasketDTO>(basket));
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
