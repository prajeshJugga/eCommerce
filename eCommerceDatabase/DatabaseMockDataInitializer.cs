using eCommerceApi;
using eCommerceDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerceDatabase
{
    public static class DatabaseMockDataInitializer
    {
        public static void Initialize(ECommerceContext eCommerceContext) 
        {
            // Customers
            Customer customer1 = new Customer 
            {
                Address = "123 Abc Road",
                Email = "john.doe@mail.com",
                Name = "John",
                Surname = "Doe",
                Phone = "0123456789",
                Username = "jdoe",
                Password = "ASDASKLJW392ID93D9F90WODE0W-O0OD0FF3ORD0F0"
            };
            Customer customer2 = new Customer
            {
                Address = "123 Xyz Road",
                Email = "jane.edo@mail.com",
                Name = "Jane",
                Surname = "Edo",
                Phone = "1123456789",
                Username = "jane_e",
                Password = "ASDASKLJW392ID93D9F90WODE0W-O0OD0FF3ORD0F0"
            };
            eCommerceContext.Customers.AddRange(customer1, customer2);
            eCommerceContext.SaveChanges();

            // Brand
            Brand lg = new Brand { Name = "LG", Description = "LG" };
            Brand samsung = new Brand { Name = "Samsung", Description = "Samsung" };
            Brand dell = new Brand { Name = "DELL" , Description = "DELL" };
            Brand msi = new Brand { Name = "MSi" , Description = "MSi" };
            Brand logitech = new Brand { Name = "Logitech" , Description = "Logitech" };
            eCommerceContext.Brands.AddRange(lg, samsung, dell, msi, logitech);
            eCommerceContext.SaveChanges();

            // Categories
            Category monitors = new Category { Name = "Monitors", Description = "Computer Monitors" };
            Category laptops = new Category { Name = "Laptops", Description = "Laptops" };
            Category desktops = new Category { Name = "Desktop PCs", Description = "Desktop PCs" };
            Category mice = new Category { Name = "Mice", Description = "Mice" };
            eCommerceContext.ProductCategories.AddRange(monitors, laptops, desktops, mice);
            eCommerceContext.SaveChanges();

            // Products
            Product lgMonitor = new Product
            {
                Name = "LG LCD TV Monitor 20'",
                Description = "LG LCD TV Monitor 20'",
                CategoryId = monitors.Id,
                BrandId = lg.Id,
                Price = 1299,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            Product dellLaptop = new Product
            {
                Name = "DELL Gaming Laptop",
                Description = "DELL Gaming Laptop, Intel i7, 32GB DDR5 RAM, 512GB SSD, 4GB Nvidia GEForce",
                CategoryId = laptops.Id,
                BrandId = dell.Id,
                Price = 9999,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            Product logitechMouse = new Product
            {
                Name = "Logitech Mouse",
                Description = "Logitech RGB Gaming Mouse",
                CategoryId = mice.Id,
                BrandId = logitech.Id,
                Price = 899,
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
            };

            eCommerceContext.Products.AddRange(lgMonitor, dellLaptop, logitechMouse);
            eCommerceContext.SaveChanges();

            // BundleTypes
            BundleType comboBundleType = new BundleType
            {
                Name = "Bundle Deals",
                Description = "Bundle type that is used for specials that involve bundle deals e.g) keyboard and mice combo deals"
            };
            eCommerceContext.BundleTypes.Add(comboBundleType);
            eCommerceContext.SaveChanges();

            // ActiveSpecial
            ActiveSpecial homeOfficeSpecial = new ActiveSpecial
            {
                BundleTypeId = comboBundleType.Id,
                Name = "Monitor + Laptop 20% off total",
                Description = "Buy any Laptop and Monitor and get 20% off your total",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddDays(2),
                PercentageOff = 0.2,
                ProductsOnSpecial = new List<ProductOnSpecial> {
                    new ProductOnSpecial 
                    {
                        ProductId = dellLaptop.Id,
                        RequiredQuantity = 1,
                    },
                    new ProductOnSpecial
                    {
                        ProductId = lgMonitor.Id,
                        RequiredQuantity = 1,
                    }
                }
            };
            eCommerceContext.ActiveSpecials.Add(homeOfficeSpecial);
            eCommerceContext.SaveChanges();

            // Invoices -> this is purely for running the Stored Proc
            Invoice invoice1 = new Invoice
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CustomerId = customer1.Id,
                Total = 22596,
                Items = new List<InvoiceItem>
                {

                }
            };
            eCommerceContext.Invoices.Add(invoice1);
            eCommerceContext.SaveChanges();

            List<InvoiceItem> invoice1Items = new List<InvoiceItem>
            {
                new InvoiceItem
                {
                    InvoiceId = invoice1.Id,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = customer1.Id,
                    ProductId = lgMonitor.Id,
                    Quantity = 2,
                    Price = lgMonitor.Price * 2,
                },
                new InvoiceItem
                {
                    InvoiceId = invoice1.Id,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = customer1.Id,
                    ProductId = dellLaptop.Id,
                    Quantity = 2,
                    Price = lgMonitor.Price * 2,
                }
            };
            eCommerceContext.InvoiceItems.AddRange(invoice1Items);
            eCommerceContext.SaveChanges();


            Invoice invoice2 = new Invoice
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CustomerId = customer1.Id,
                Total = 2598,
                Items = new List<InvoiceItem>
                {
                }
            };
            eCommerceContext.Invoices.Add(invoice2);
            eCommerceContext.SaveChanges();

            List<InvoiceItem> invoice2Items = new List<InvoiceItem>
            {
                new InvoiceItem
                {
                    InvoiceId = invoice2.Id,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = customer1.Id,
                    ProductId = lgMonitor.Id,
                    Quantity = 2,
                    Price = lgMonitor.Price * 2,
                },
            };
            eCommerceContext.InvoiceItems.AddRange(invoice2Items);
            eCommerceContext.SaveChanges();


            Invoice invoice3 = new Invoice
            {
                CreatedDate = DateTime.Now,
                ModifiedDate = DateTime.Now,
                CustomerId = customer1.Id,
                Total = 2598,
                Items = new List<InvoiceItem>
                {

                }
            };
            eCommerceContext.Invoices.Add(invoice3);
            eCommerceContext.SaveChanges();

            List<InvoiceItem> invoice3Items = new List<InvoiceItem>
            {
                    new InvoiceItem
                    {
                        InvoiceId = invoice3.Id,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Id = customer1.Id,
                        ProductId = lgMonitor.Id,
                        Quantity = 3,
                        Price = lgMonitor.Price * 3,
                    },
            };
            eCommerceContext.InvoiceItems.AddRange(invoice3Items);
            eCommerceContext.SaveChanges();

        }
    }
}
