using eCommerceApi.Services.BusinessLogic;
using eCommerceDatabase.DTOs;

namespace eCommerceApi.Services
{
    public interface IBasketService
    {
        Task<BasketDTO> AddBasketItem(BasketItemDTO item, int customerId, int activeSpecialId);
    }
}
