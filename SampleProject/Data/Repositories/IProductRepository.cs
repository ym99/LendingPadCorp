using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IProductRepository
    {
        Product Get(Guid id);
        IEnumerable<Product> GetAll(string nameSearchCriteria = null, string descriptionSearchCriteria = null, int? maxPrice = null, int? minRating = null);

        void Create(Product product);
        void Update(Product product);
        void Delete(Guid id);
    }
}