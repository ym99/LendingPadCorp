using System;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface ICreateOrderService
    {
        Order CreateOrder(Guid userId, Guid productId, int quantity);
    }
}