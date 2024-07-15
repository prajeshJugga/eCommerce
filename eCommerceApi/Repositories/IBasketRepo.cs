using eCommerceApi.Services.BusinessLogic;
using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories
{
    public interface IBasketRepo
    {
        Basket? GetBasketByCustomerId(int customerId);
        Task<Basket> AddBasketItem(BasketItemDTO item, int customerId, int activeSpecialId, IBasketCalculator basketCalculators);
    }
}
