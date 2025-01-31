using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Core.Services.Orders
{
    public interface IUpdateOrderService
    {
        /// <summary>
        /// Handles all cases:
        /// - adding a new product to order
        /// - adding quantity to a product that is already in the order
        /// - removing quantity from a product that is already in the order
        /// - removing a product from the order if its quantity becomes zero or negative
        /// </summary>
        /// <param name="id"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        Order UpdateOrderAddProduct(Guid id, Guid productId, int quantity);
        Order UpdateOrderDeleteProduct(Guid id, Guid productId);
    }
}