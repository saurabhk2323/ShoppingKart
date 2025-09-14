using InventoryManagement.DTOs;
namespace InventoryManagement.Contracts
{
    /// <summary>
    /// Interface for service operations related to product management.
    /// </summary>
    public interface IProductsService
    {
        /// <summary>
        /// Creates a new product and returns its details.
        /// </summary>
        Task<ResponseProductDto> CreateProduct(CreateProductDto createProductDto);

        /// <summary>
        /// Gets details of all products.
        /// </summary>
        Task<IEnumerable<ResponseProductDto>> GetProducts();

        /// <summary>
        /// Gets details of a product by its ID.
        /// </summary>
        Task<ResponseProductDto?> GetProduct(int productId);

        /// <summary>
        /// Updates a product's details and returns the updated product.
        /// </summary>
        Task<ResponseProductDto?> UpdateProduct(int productId, UpdateProductDto updateProductDto);

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        Task<bool> DeleteProduct(int productId);

        /// <summary>
        /// Adds quantity to the stock of a product.
        /// </summary>
        Task<bool> AddToStock(int productId, int quantity);

        /// <summary>
        /// Decreases the stock of a product by a given quantity.
        /// </summary>
        Task<bool> DecrementStock(int productId, int quantity);
    }
}
