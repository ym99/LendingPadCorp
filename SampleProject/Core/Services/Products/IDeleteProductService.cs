using BusinessEntities;
using System;

namespace Core.Services.Products
{
    public interface IDeleteProductService
    {
        void DeleteProduct(Guid id);
    }
}