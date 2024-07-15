using eCommerceApi.Exceptions;
using eCommerceApi.Services.BusinessLogic;
using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories
{
    public class BasketRepository : IBasketRepo
    {
        private readonly ECommerceContext _context;
        private readonly ILogger<ProductRepository> _logger;
        private readonly IActiveSpecialRepository _activeSpecialRepository;
        private readonly IProductRepo _productRepo;

        public BasketRepository(ECommerceContext context, 
            ILogger<ProductRepository> logger,
            IActiveSpecialRepository activeSpecialRepository,
            IProductRepo productRepo)
        {
            _context = context;
            _logger = logger;
            _activeSpecialRepository = activeSpecialRepository;
            _productRepo = productRepo;
        }

        public async Task<Basket> AddBasketItem(BasketItemDTO newBasketItemDTO, int customerId, int activeSpecialId, IBasketCalculator basketCalculator)
        {
            Basket? latestBasket = GetBasketByCustomerId(customerId);
            Product? product = _productRepo.GetProductById(newBasketItemDTO.ProductId);
            ActiveSpecial activeSpecial = _activeSpecialRepository.GetActiveSpecialById(activeSpecialId);

            newBasketItemDTO.Price = product.Price;
            // If there is no active basket for the user, create a new one, and add the new BasketItem
            if (latestBasket == null)
            {
                latestBasket = new Basket
                {
                    CreatedDate = DateTime.UtcNow,
                    ModifiedDate = DateTime.UtcNow,
                    CustomerId = customerId,
                    Items = new List<BasketItem> { new BasketItem(newBasketItemDTO) },
                    ProgressedToOrder = false
                };

                basketCalculator.CalculateBasketPrice(ref latestBasket, activeSpecial);
                await _context.Baskets.AddAsync(latestBasket);
                await _context.SaveChangesAsync();
            }
            // If there is an existing basket, first check if the BasketItem already exists to correctly handle the quantity and price
            else
            {
                //BasketItem? existingBasketItem = latestBasket.Items.SingleOrDefault(i => i.ProductId == product.Id);
                BasketItem? existingBasketItem = GetBasketItemByBasketId(latestBasket.Id, product.Id);
                if (existingBasketItem == null)
                {
                    BasketItem newBasketItem = new BasketItem(newBasketItemDTO);
                    newBasketItem.BasketId = latestBasket.Id;
                    latestBasket.Items.Add(newBasketItem);

                    basketCalculator.CalculateBasketPrice(ref latestBasket, activeSpecial);
                    _context.Baskets.Update(latestBasket);
                    //await _context.BasketItems.AddAsync(newBasketItem);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    existingBasketItem.Quantity += newBasketItemDTO.Quantity;
                    basketCalculator.CalculateBasketPrice(ref latestBasket, activeSpecial);
                    //_context.BasketItems.Update(existingBasketItem);
                    _context.Baskets.Update(latestBasket);
                    await _context.SaveChangesAsync();
                }
            }


            return latestBasket;
        }

        public Basket? GetBasketByCustomerId(int customerId)
        {

            try
            {
                // Get the latest bucket if more than one exists, and one that hasn't been ordered
                Basket customerBaskets = _context.Baskets
                    .Where(i => i.Customer.Id == customerId && !i.ProgressedToOrder)
                    .OrderByDescending(b => b.ModifiedDate)
                    .FirstOrDefault();
                return customerBaskets;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

        private BasketItem? GetBasketItemByBasketId(int basketId, int productId)
        {

            try
            {
                // Get the latest bucket if more than one exists, and one that hasn't been ordered
                BasketItem basketItem = _context.BasketItems
                    .Where(i => i.BasketId == basketId && i.ProductId == productId)
                    .FirstOrDefault();
                return basketItem;
            }
            catch (ArgumentNullException)
            {
                return null;
            }
        }

    }
}
