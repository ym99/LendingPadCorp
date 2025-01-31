using BusinessEntities;
using System;

namespace WebApi.Models.Orders
{
    public class OrderProductData
    {
        public OrderProductData(OrderProduct orderProduct)
        {
            ProductId = orderProduct.ProductId;
            Quantity = orderProduct.Quantity;
        }

        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}