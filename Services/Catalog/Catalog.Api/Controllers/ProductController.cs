using Catalog.ApplicationService.DTOs;
using Catalog.ApplicationService.Services;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Api.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Constructor
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }
        #endregion Constructor

        #region Actions

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            var result = await _productService.GetProductById(id);
            return Ok(result);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetProductsByName(string name)
        {
            var result = await _productService.GetProductsByName(name);
            return Ok(result);
        }

        [HttpGet("{category}")]
        public async Task<IActionResult> GetProductsByCategory(string category)
        {
            var result = await _productService.GetProductsByCategory(category);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductOperationDTO request)
        {
            var result = await _productService.CreateProduct(request);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(ProductOperationDTO request)
        {
            var result = await _productService.UpdateProduct(request);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            var result = await _productService.DeleteProduct(id);
            return Ok(result);
        }
        #endregion Actions
    }
}
