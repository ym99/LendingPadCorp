using System;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Orders;
using Core.Services.Products;
using WebApi.Models.Orders;
using WebApi.Models.Products;

namespace WebApi.Controllers
{
    [RoutePrefix("orders")]
    public class OrderController : BaseApiController
    {
        private readonly ICreateOrderService _createOrderService;
        private readonly IDeleteOrderService _deleteOrderService;
        private readonly IGetOrderService _getOrderService;
        private readonly IUpdateOrderService _updateOrderService;

        public OrderController(ICreateOrderService createOrderService, IDeleteOrderService deleteOrderService, IGetOrderService getOrderService, IUpdateOrderService updateOrderService)
        {
            _createOrderService = createOrderService;
            _deleteOrderService = deleteOrderService;
            _getOrderService = getOrderService;
            _updateOrderService = updateOrderService;
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage CreateOrder([FromBody] CreateOrderModel orderModel)
        {
            var order = _createOrderService.CreateOrder(orderModel.UserId, orderModel.ProductId, orderModel.Quantity);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            _deleteOrderService.DeleteOrder(orderId);
            return Found();
        }

        [Route("{orderId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetOrder(Guid orderId)
        {
            var order = _getOrderService.GetOrder(orderId);
            if (order == null)
            {
                return DoesNotExist();
            }

            return Found(new OrderData(order));
        }
        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetOrders()
        {
            var orders = _getOrderService.GetAllOrders();
            return Found(orders);
        }

        [Route("{orderId:guid}/products/{productId:guid}/update")]
        [HttpPost]
        // this method can be used to add a new Product to Order or
        // change the existing product's quatity so HttpPost method is used
        public HttpResponseMessage UpdateOrderAddProduct(Guid orderId, Guid productId, [FromBody] UpdateOrderAddProduct orderModel)
        {
            var order = _updateOrderService.UpdateOrderAddProduct(orderId, productId, orderModel.Quantity);
            return Found(new OrderData(order));
        }

        [Route("{orderId:guid}/products/{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage UpdateOrderDeleteProduct(Guid orderId, Guid productId)
        {
            var order = _updateOrderService.UpdateOrderDeleteProduct(orderId, productId);
            return Found(new OrderData(order));
        }

    }
}
