using AutoMapper;
using InventoryManagement.Contracts;
using InventoryManagement.DTOs;
using InventoryManagement.Entities;

namespace InventoryManagement.Services
{
    /// <summary>
    /// Service for managing product operations such as create, update, delete, and stock management.
    /// </summary>
    public class ProductsService : IProductsService
    {
        private readonly ILogger<ProductsService> _logger;
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;

        // Constructor injects logger, mapper, and repository dependencies
        public ProductsService(ILogger<ProductsService> logger, IMapper mapper, IProductsRepository productsRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _productsRepository = productsRepository;
        }

        /// <summary>
        /// Adds quantity to the stock of a product.
        /// </summary>
        public async Task<bool> AddToStock(int productId, int quantity)
        {
            var product = await _productsRepository.GetByIdAsync(productId);

            if (product == null) return false;

            product.StockAvailable += quantity;

            await _productsRepository.UpdateAsync(productId, product);

            return true;
        }

        /// <summary>
        /// Creates a new product and returns its details.
        /// </summary>
        public async Task<ResponseProductDto> CreateProduct(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);

            await _productsRepository.AddAsync(product);

            return _mapper.Map<ResponseProductDto>(product);
        }

        /// <summary>
        /// Decreases the stock of a product by a given quantity.
        /// </summary>
        public async Task<bool> DecrementStock(int productId, int quantity)
        {
            var product = await _productsRepository.GetByIdAsync(productId);

            if (product == null || product.StockAvailable < quantity) return false;

            product.StockAvailable -= quantity;

            Product? updatedProductDetails = await _productsRepository.UpdateAsync(productId, product);

            return true;
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        public async Task<bool> DeleteProduct(int productId)
        {
            return await _productsRepository.DeleteAsync(productId);
        }

        /// <summary>
        /// Gets details of a product by its ID.
        /// </summary>
        public async Task<ResponseProductDto?> GetProduct(int productId)
        {
            var product = await _productsRepository.GetByIdAsync(productId);

            if (product == null) return null;

            return _mapper.Map<ResponseProductDto>(product);
        }

        /// <summary>
        /// Gets details of all products.
        /// </summary>
        public async Task<IEnumerable<ResponseProductDto>> GetProducts()
        {
            var products = await _productsRepository.GetAllAsync();

            return products.Select(p => _mapper.Map<ResponseProductDto>(p));
        }

        /// <summary>
        /// Updates a product's details and returns the updated product.
        /// </summary>
        public async Task<ResponseProductDto?> UpdateProduct(int productId, UpdateProductDto updateProductDto)
        {
            var updatedProductDetails = _mapper.Map<Product>(updateProductDto);

            var product = await _productsRepository.UpdateAsync(productId, updatedProductDetails);

            if (product == null) return null;

            return _mapper.Map<ResponseProductDto>(product);
        }
    }
}
