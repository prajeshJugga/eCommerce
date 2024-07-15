using eCommerceDatabase.Models;

namespace eCommerceApi.Services.BusinessLogic
{
    public interface IBasketCalculator
    {
        void CalculateBasketPrice(ref Basket basket, ActiveSpecial activeSpecial);
    }
}
