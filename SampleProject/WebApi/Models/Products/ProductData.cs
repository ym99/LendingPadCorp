using BusinessEntities;
using System;
using System.Collections.Generic;

namespace WebApi.Models.Products
{
    public class ProductData
    {
        public ProductData(Product product)
        {
            Id = product.Id;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Rating = product.Rating;
            ImageUrl = product.ImageUrl;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Rating { get; set; }
        public string ImageUrl { get; set; }
    }
}