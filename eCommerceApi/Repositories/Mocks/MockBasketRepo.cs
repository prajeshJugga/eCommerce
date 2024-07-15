using eCommerceApi.Exceptions;
using eCommerceDatabase.DTOs;
using eCommerceDatabase.Models;

namespace eCommerceApi.Repositories.Mocks
{
    public class MockBasketRepo //: IBasketRepo
    {
        private readonly IProductRepo _productRepo;
        private readonly ICustomerRepo _customerRepo;
        private readonly ILogger<MockBasketRepo> _logger;
        private List<Basket> _basketList;

        public MockBasketRepo(ILogger<MockBasketRepo> logger,
                              IProductRepo productRepo,
                              ICustomerRepo customerRepo)
        {
            _logger = logger;
            _productRepo = productRepo;
            _customerRepo = customerRepo;

            List<Product> products = _productRepo.GetProducts();
            List<Customer> customers = _customerRepo.GetAll();

            _basketList = new List<Basket>
            {
                new Basket
                {
                    Id = 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Customer = _customerRepo.GetCustomerById(1),
                    Items = new List<BasketItem>
                    {
                        new BasketItem
                        {
                            Id = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            Product = products[0],
                            Price = 0,
                            Quantity = 2
                        },
                        new BasketItem
                        {
                            Id = 2,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            Product = products[0],
                            Price = 0,
                            Quantity = 1
                        },

                        new BasketItem
                        {
                            Id = 3,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            Product = products[0],
                            Price = 0,
                            Quantity = 1
                        },
                    }
                },
                new Basket
                {
                    Id = 2,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Customer = _customerRepo.GetCustomerById(2),
                    Items = new List<BasketItem>
                    {
                        new BasketItem
                        {
                            Id = 1,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            Product = products[0],
                            Price = 0,
                            Quantity = 2
                        },
                        new BasketItem
                        {
                            Id = 2,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            Product = products[0],
                            Price = 0,
                            Quantity = 1
                        },

                        new BasketItem
                        {
                            Id = 3,
                            CreatedDate = DateTime.Now,
                            ModifiedDate = DateTime.Now,
                            Product = products[0],
                            Price = 0,
                            Quantity = 1
                        },
                    }
                }
            };
        }

        public async Task<Basket> AddBasketItem(BasketItemDTO item, int customerId)
        {
            Basket basket = GetBasketByCustomerId(customerId);
            if (basket == null)
            {
                throw new BasketNotFoundException();
            }
            basket.Items.Add(new BasketItem(item));
            return basket;
        }

        public List<Basket> GetAllBaskets()
        {
            //return Task.FromResult(_basketList);
            return _basketList;
        }

        public Basket GetBasketByCustomerId(int customerId)
        {
            Basket basket = _basketList
                .Where(i => i.Customer.Id == customerId)
                .OrderByDescending(b => b.ModifiedDate).FirstOrDefault();
            if (basket == null)
            {
                basket = new Basket
                {
                    Id = _basketList.Last().Id + 1,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Customer = _customerRepo.GetCustomerById(customerId),
                    Items = new List<BasketItem>()
                };
                _basketList.Add(basket);
                //throw new BasketNotFoundException();
            }
            //return Task.FromResult(basket);
            return basket;
        }
    }
}
