using System;
using System.Linq;
using BusinessEntities;
using Common;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class UpdateOrderService : IUpdateOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public UpdateOrderService(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public Order UpdateOrderAddProduct(Guid id, Guid productId, int quantity)
        {
            var order = _orderRepository.Get(id);
            if (order == null)
            {
                throw new ArgumentException($"Order with {id} does not exist");
            }

            var product = _productRepository.Get(productId);
            if (product == null)
            {
                throw new ArgumentException($"Product with {productId} does not exist");
            }

            var orderProduct = order.OrderProducts.FirstOrDefault(item => item.ProductId == productId);
            if (orderProduct == null)
            {
                order.OrderProducts.Add(
                        new OrderProduct
                        {
                            ProductId = product.Id,
                            Quantity = quantity,
                        }
                    );

                order.Total += product.Price * quantity;
                return order;
            }

            order.Total += product.Price * (quantity - orderProduct.Quantity);
            orderProduct.Quantity = quantity;

            return order;
        }

        public Order UpdateOrderDeleteProduct(Guid id, Guid productId)
        {
            var order = _orderRepository.Get(id);
            if (order == null)
            {
                throw new ArgumentException($"Order with {id} does not exist");
            }

            var product = _productRepository.Get(productId);
            if (product == null)
            {
                throw new ArgumentException($"Product with {productId} does not exist");
            }

            var orderProduct = order.OrderProducts.FirstOrDefault(item => item.ProductId == productId);
            if (orderProduct != null)
            {
                order.OrderProducts.Remove(orderProduct);

                order.Total -= product.Price * orderProduct.Quantity;
            }

            return order;
        }
    }
}