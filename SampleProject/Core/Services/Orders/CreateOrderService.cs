using System;
using System.Diagnostics;
using System.Xml.Linq;
using BusinessEntities;
using Common;
using Core.Services.Products;
using Data.Repositories;

namespace Core.Services.Orders
{
    [AutoRegister]
    public class CreateOrderService : ICreateOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;

        public CreateOrderService(IOrderRepository orderRepository, IUserRepository userRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
            _productRepository = productRepository;
        }

        public Order CreateOrder(Guid userId, Guid productId, int quantity)
        {
            var user = _userRepository.Get(userId);
            if (user == null)
            {
                throw new ArgumentException($"User with {userId} does not exist");
            }

            var product = _productRepository.Get(productId);
            if (product == null) {
                throw new ArgumentException($"Product with {productId} does not exist");
            }

            var order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                OrderProducts = new OrderProduct[]
                {
                    new OrderProduct
                    {
                        ProductId = product.Id,
                        Quantity = quantity
                    }
                },

                Total = product.Price * quantity
            };

            _orderRepository.Create(order);

            return order;
        }
    }
}