using System;
using System.Collections.Generic;
using Common.Extensions;

namespace BusinessEntities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }
    }
}