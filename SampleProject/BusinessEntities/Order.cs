using System;
using System.Collections.Generic;
using Common.Extensions;

namespace BusinessEntities
{
    public class Order
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public IList<OrderProduct> OrderProducts { get; set; }
        public decimal Total { get; set; }
    }
}