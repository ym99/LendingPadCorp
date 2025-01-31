using BusinessEntities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;

namespace WebApi.Models.Orders
{
    public class OrderData
    {
        public OrderData(Order order)
        {
            Id = order.Id;
            UserId = order.UserId;
            OrderProducts = order.OrderProducts.Select(product => new OrderProductData(product)).ToList();
            Total = order.Total;
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IEnumerable<OrderProductData> OrderProducts { get; set; }
        public decimal Total { get; set; }
    }
}