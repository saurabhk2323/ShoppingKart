using InventoryManagement.Entities;

namespace InventoryManagement.Contracts
{
    /// <summary>
    /// Interface for repository operations related to Product entities.
    /// </summary>
    public interface IProductsRepository
    {
        /// <summary>
        /// Adds a new product to the repository.
        /// </summary>
        Task AddAsync(Product product);

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        Task<Product?> GetByIdAsync(int productId);

        /// <summary>
        /// Gets all products from the repository.
        /// </summary>
        Task<List<Product>> GetAllAsync();

        /// <summary>
        /// Updates an existing product's details.
        /// </summary>
        Task<Product?> UpdateAsync(int productId, Product product);

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        Task<bool> DeleteAsync(int productId);
    }
}
