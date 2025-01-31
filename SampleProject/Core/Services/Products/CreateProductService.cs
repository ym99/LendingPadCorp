using System;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class CreateProductService : ICreateProductService
    {
        private readonly IProductRepository _productRepository;

        public CreateProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product CreateProduct(string name, string description, decimal price, int rating, string imageUrl)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = name,
                Description = description,
                Price = price,
                Rating = rating,
                ImageUrl = imageUrl
            };

            _productRepository.Create(product);

            return product;
        }
    }
}