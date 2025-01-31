using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Products
{
    public interface ICreateProductService
    {
        Product CreateProduct(string name, string description, decimal price, int rating, string imageUrl);
    }
}