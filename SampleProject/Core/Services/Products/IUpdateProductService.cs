using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface IUpdateProductService
    {
        Product UpdateProduct(Guid id, string name, string description, decimal price, int rating, string imageUrl);
    }
}