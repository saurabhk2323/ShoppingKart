using InventoryManagement.Contracts;
using InventoryManagement.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;

        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        // POST: api/products
        [HttpPost]
        public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(ms => ms.Value?.Errors.Count > 0)
                    .SelectMany(ms => ms.Value!.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                return BadRequest(errors);
            }

            var response = await _productsService.CreateProduct(createProductDto);

            return Created(nameof(CreateProductAsync), response);
        }

        // GET: api/products
        [HttpGet]
        public async Task<IActionResult> GetProductsAsync()
        {
            var products = await _productsService.GetProducts();

            return Ok(products);
        }

        // GET: api/products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductAsync(int id)
        {
            var product = await _productsService.GetProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/products/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProductAsync(int id, UpdateProductDto updateProductDto)
        {
            if(!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(ms => ms.Value?.Errors.Count > 0)
                    .SelectMany(ms => ms.Value!.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                return BadRequest(errors);
            }
            var updatedProduct = await _productsService.UpdateProduct(id, updateProductDto);

            if (updatedProduct == null)
            {
                return NotFound();
            }

            return Ok(updatedProduct);
        }

        // DELETE: api/products/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            bool productStatus = await _productsService.DeleteProduct(id);

            if (!productStatus)
            {
                return NotFound();
            }

            return NoContent();
        }

        // PUT: api/products/decrement-stock/{id}/{quantity}
        [HttpPut("decrement-stock/{id}/{quantity}")]
        public async Task<IActionResult> DecrementStockAsync(int id, int quantity)
        {
            bool productStatus = await _productsService.DecrementStock(id, quantity);

            if (!productStatus)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/products/add-to-stock/{id}/{quantity}
        [HttpPut("add-to-stock/{id}/{quantity}")]
        public async Task<IActionResult> AddToStockAsync(int id, int quantity)
        {
            bool productStatus = await _productsService.AddToStock(id, quantity);

            if (!productStatus)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
