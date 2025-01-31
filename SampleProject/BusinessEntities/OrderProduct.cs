using System;

namespace BusinessEntities
{
    public class OrderProduct
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}