using BusinessEntities;
using System;

namespace Core.Services.Orders
{
    public interface IDeleteOrderService
    {
        void DeleteOrder(Guid id);
    }
}