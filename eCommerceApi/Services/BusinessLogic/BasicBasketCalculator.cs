using eCommerceApi.Repositories;
using eCommerceDatabase.Models;

namespace eCommerceApi.Services.BusinessLogic
{
    public class BasicBasketCalculator : IBasketCalculator
    {
        private readonly IProductRepo _productRepo;
        public BasicBasketCalculator(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }
        // Assume that the same product cannot appear on more than one special
        // Assume that a bundle deal won't allow more than one type of the same product (bad assumption, but for simplicity of solution)
        public void CalculateBasketPrice(ref Basket basket, ActiveSpecial activeSpecial)
        {
            bool specialDetected = true;
            if (activeSpecial != null)
            {
                //Dictionary<BasketItem, SetDetails> matchedItems = new Dictionary<BasketItem, SetDetails>();
                foreach (var productSpecial in activeSpecial.ProductsOnSpecial)
                {
                    BasketItem basketItem = basket.Items.SingleOrDefault(i => i.ProductId == productSpecial.ProductId);

                    if (basketItem == null || basketItem.Quantity != productSpecial.RequiredQuantity)
                    {
                        specialDetected = false;
                        // If a product does not exist for the special, then it won't apply at all, hence stop calculating it
                        break;
                    }
                }

                if (specialDetected)
                {
                    foreach (var item in basket.Items)
                    {
                        Product? product = _productRepo.GetProductById(item.ProductId);
                        item.Price = GetSpecialPrice(product.Price, item.Quantity, activeSpecial.PercentageOff);
                    }
                }
            }
            basket.Total = basket.Items.Sum(i => i.Price);
        }

        private static double GetSpecialPrice(double originalPrice, int quantity, double percentageDeduction)
        {
            return quantity * (originalPrice - (percentageDeduction * originalPrice));
        }
    }
}
