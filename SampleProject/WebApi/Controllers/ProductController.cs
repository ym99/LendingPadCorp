using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using BusinessEntities;
using Core.Services.Products;
using WebApi.Models.Products;
using WebApi.Models.Users;

namespace WebApi.Controllers
{
    [RoutePrefix("products")]
    public class ProductController : BaseApiController
    {
        private readonly ICreateProductService _createProductService;
        private readonly IDeleteProductService _deleteProductService;
        private readonly IGetProductService _getProductService;
        private readonly IUpdateProductService _updateProductService;

        public ProductController(ICreateProductService createProductService, IDeleteProductService deleteProductService, IGetProductService getProductService, IUpdateProductService updateProductService)
        {
            _createProductService = createProductService;
            _deleteProductService = deleteProductService;
            _getProductService = getProductService;
            _updateProductService = updateProductService;
        }

        [Route("create")]
        [HttpPost]
        public HttpResponseMessage CreateProduct([FromBody] CreateProductModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = _createProductService.CreateProduct(model.Name, model.Description, model.Price, model.Rating, model.ImageUrl);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/update")]
        [HttpPut]
        public HttpResponseMessage UpdateProduct(Guid productId, [FromBody] UpdateProductModel model)
        {
            var product = _updateProductService.UpdateProduct(productId, model.Name, model.Description, model.Price, model.Rating, model.ImageUrl);
            return Found(new ProductData(product));
        }

        [Route("{productId:guid}/delete")]
        [HttpDelete]
        public HttpResponseMessage DeleteProduct(Guid productId)
        {
             _deleteProductService.DeleteProduct(productId);
            return Found();
        }

        [Route("{productId:guid}")]
        [HttpGet]
        public HttpResponseMessage GetProduct(Guid productId)
        {
            var product = _getProductService.GetProduct(productId);
            return Found(new ProductData(product));
        }

        [Route("list")]
        [HttpGet]
        public HttpResponseMessage GetProducts(int skip = 0, int take = int.MaxValue, string name = null, string description = null, int? price = null, int? rating = null)
        {
            var products = _getProductService
                            .GetAllProducts(name, description, price, rating)
                            .Skip(skip).Take(take)
                            .Select(q => new ProductData(q))
                            .ToList();

            return Found(products);
        }
    }
}
