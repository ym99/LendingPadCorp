using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class ProductRepository : IProductRepository
    {
        List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = new Guid("7c866ada-5c51-47c8-812e-d8c2cd5f7f17"),
                Name = "PHILIPS Series 2300 Fully Automatic Espresso Machine",
                Description = "Customizable Coffee Crafting: With the My Coffee Choice function, you can personalize your coffee strength, length, and milk froth level to suit your taste preferences.\r\nEffortless Milk Frothing: The LatteGo system automatically prepares silky smooth milk froth for delectable cappuccinos and lattes, and is remarkably easy to clean with just two parts and no tubing.\r\nIntuitive Touch Control: The modern touch screen display with colored icons allows for easy selection of your favorite drinks, including espresso, coffee, cappuccino, and hot water.\r\nQuiet Brewing Experience: Savor the aroma of freshly brewed coffee without unnecessary noise thanks to the industry-leading SilentBrew technology.\r\nLong-Lasting Ceramic Grinder: The durable ceramic grinder with 12 adjustable settings ensures your coffee beans are ground to perfection, unlocking their full flavor potential.\r\nHassle-Free Maintenance: The AquaClean filter eliminates the need for descaling for up to 5000 cups, ensuring you enjoy clear and purified water in every brew.",
                Price = 555.09m,
                Rating = 4,
                ImageUrl = "https://a.media-amazon.com/images/I/61t6XIxGQFL._AC_SL1500_.jpg"
            },
            new Product
            {
                Id = new Guid("56f214bf-b4dd-47eb-ad0e-f2b59a575deb"),
                Name = "5-Cup Coffee Machines with Reusable Filter, Coffee Pots, Black & Stainless Steel",
                Description = "CONVENIENT DESIGN: This small coffee maker is convenient for homes, apartments, and offices due to its 5 cup capacity, fitting easily into compact spaces\r\nSIMPLE OPERATION: Brew with ease using this drip coffee maker by pressing the ON/OFF switch. The indicator light clearly shows when the coffee maker is active for added convenience\r\nKEEP YOUR COFFEE HOT: This 5-Cup coffee maker has a warming plate that keeps your brew warm until you turn it off, without scorching\r\nOVERHEAT PROTECTION: This stainless steel coffee machine prevents stops brewing when water is low or temperature exceeds the rated temperature, helping prevent overheating and dry-boiling\r\nEASY MAINTENANCE: The reusable filter basket is removable for quick cleanup, reducing waste and making it easy to keep your coffee maker in top condition",
                Price = 19.99m,
                Rating = 3,
                ImageUrl = "https://a.media-amazon.com/images/I/81871DQNiAL._AC_SL1500_.jpg"
            }
        };

        public Product Get(Guid id)
        {
            return _products.FirstOrDefault(product => product.Id == id);
        }

        public IEnumerable<Product> GetAll(string nameSearchCriteria = null, string descriptionSearchCriteria = null, int? maxPrice = null, int? minRating = null)
        {
            IEnumerable<Product> products = _products;

            if (nameSearchCriteria != null)
            {
                products = products.Where(product => product.Name.ToUpper().Contains(nameSearchCriteria.ToUpper()));
            }

            if (descriptionSearchCriteria != null)
            {
                products = products.Where(product => product.Description.ToUpper().Contains(descriptionSearchCriteria.ToUpper()));
            }

            if (maxPrice != null)
            {
                products = products.Where(product => product.Price <= maxPrice);
            }

            if (minRating != null)
            {
                products = products.Where(product => product.Rating >= minRating);
            }

            return products.ToList();
        }

        public void Create(Product product)
        {
            _products.Add(product);
        }

        public void Update(Product product)
        {
            var existingProduct = _products.FirstOrDefault(x => x.Id == product.Id);
            if (existingProduct == null)
            {
                throw new Exception($"Product with id={product.Id} doesn't exist");
            }

            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Rating = product.Rating;
            existingProduct.ImageUrl = product.ImageUrl;
        }

        public void Delete(Guid id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }
}