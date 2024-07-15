using eCommerceApi.Exceptions;
using eCommerceApi.Repositories;
using eCommerceApi.Services.BusinessLogic;
using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketRepo _basketRepo;
        private readonly ILogger<BasketService> _logger;
        private readonly IBasketCalculator _basketCalculator;
        public BasketService(ILogger<BasketService> logger, 
            IBasketRepo basketRepo,
            IBasketCalculator basketCalculator) 
        {
            _basketRepo = basketRepo;
            _logger = logger;
            _basketCalculator = basketCalculator;
        }
        public async Task<BasketDTO> AddBasketItem(BasketItemDTO item, int customerId, int activeSpecialId)
        {
            Basket result = await _basketRepo.AddBasketItem(item, customerId, activeSpecialId, _basketCalculator);
            BasketDTO basketDTO = new BasketDTO(result);
            if (result == null || basketDTO == null)
            {
                throw new BasketNotFoundException();
            }
            return basketDTO;
        }
    }
}
