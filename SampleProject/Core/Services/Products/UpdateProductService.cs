using System;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class UpdateProductService : IUpdateProductService
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product UpdateProduct(Guid id, string name, string description, decimal price, int rating, string imageUrl)
        {
            var product = new Product
            {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                Rating = rating,
                ImageUrl = imageUrl
            };

            _productRepository.Update(product);

            return product;
        }
    }
}