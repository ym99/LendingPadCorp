using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface IGetProductService
    {
        Product GetProduct(Guid id);

        IEnumerable<Product> GetAllProducts(string nameSearchCriteria = null, string descriptionSearchCriteria = null, int? maxPrice = null, int? minRating = null);
    }
}