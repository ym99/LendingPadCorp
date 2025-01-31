﻿using System;
using System.Collections.Generic;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Products
{
    [AutoRegister]
    public class GetProductService : IGetProductService
    {
        private readonly IProductRepository _productRepository;

        public GetProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProduct(Guid id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetAllProducts(string nameSearchCriteria = null, string descriptionSearchCriteria = null, int? maxPrice = null, int? minRating = null)
        {
            return _productRepository.GetAll(nameSearchCriteria, descriptionSearchCriteria, maxPrice, minRating);
        }
    }
}