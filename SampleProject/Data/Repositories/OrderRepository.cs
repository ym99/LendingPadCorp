using System;
using System.Collections.Generic;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Indexes;
using Raven.Client;

namespace Data.Repositories
{
    [AutoRegister(AutoRegisterTypes.Singleton)]
    public class OrderRepository : IOrderRepository
    {
        List<Order> _orders = new List<Order>
        {
            new Order
            {
                Id = new Guid("59e095f9-03e4-413f-b11f-b164479a3574"),
                UserId = new Guid("9422740e-6426-4c46-8445-3f5274a62424"),
                OrderProducts = new List<OrderProduct>
                {
                    new OrderProduct
                    {
                        ProductId = new Guid("7c866ada-5c51-47c8-812e-d8c2cd5f7f17"),
                        Quantity = 7
                    }
                },
                Total = 3885.63m
            },
        };

        public Order Get(Guid id)
        {
            return _orders.FirstOrDefault(order => order.Id == id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders;
        }

        public void Create(Order order)
        {
            _orders.Add(order);
        }

        public void Update(Order order)
        {
            var existingOrder = _orders.FirstOrDefault(x => x.Id == order.Id);
            if (existingOrder == null)
            {
                throw new Exception($"Order with id={order.Id} doesn't exist");
            }

            existingOrder.UserId = order.UserId;
            existingOrder.OrderProducts = order.OrderProducts;
            existingOrder.Total = order.Total;
        }

        public void Delete(Guid id)
        {
            var order = _orders.FirstOrDefault(x => x.Id == id);
            if (order != null)
            {
                _orders.Remove(order);
            }
        }
    }
}