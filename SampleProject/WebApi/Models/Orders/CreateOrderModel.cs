using BusinessEntities;
using System;

namespace WebApi.Models.Orders
{
    public class CreateOrderModel
    {
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}