using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IOrderRepository
    {
        Order Get(Guid id);
        IEnumerable<Order> GetAll();

        void Create(Order order);
        void Update(Order order);
        void Delete(Guid id);
    }
}