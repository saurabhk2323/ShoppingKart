using InventoryManagement.Contracts;
using InventoryManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement.Infrastructure
{
    /// <summary>
    /// Repository for handling CRUD operations and data access for Product entities.
    /// </summary>
    public class ProductsRepository : IProductsRepository
    {
        private readonly ILogger<ProductsRepository> _logger;
        private readonly AppDbContext _db;

        /// <summary>
        /// Initializes a new instance of ProductsRepository with logger and database context.
        /// </summary>
        public ProductsRepository(ILogger<ProductsRepository> logger, AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        /// <summary>
        /// Adds a new product to the database.
        /// </summary>
        public async Task AddAsync(Product product)
        {
            product.CreatedAt = DateTime.UtcNow;
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Deletes a product by its ID.
        /// </summary>
        public async Task<bool> DeleteAsync(int productId)
        {
            var product = _db.Products.Find(productId);

            if (product == null) return false;

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Gets all products from the database.
        /// </summary>
        public async Task<List<Product>> GetAllAsync()
        {
            return await _db.Products.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Gets a product by its ID.
        /// </summary>
        public async Task<Product?> GetByIdAsync(int productId)
        {
            return await _db.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == productId);
        }

        /// <summary>
        /// Updates an existing product's details.
        /// </summary>
        public async Task<Product?> UpdateAsync(int productId, Product product)
        {
            var existingProduct = await _db.Products.FindAsync(productId);

            if (existingProduct == null) return null;
            
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Category = product.Category;
            existingProduct.StockAvailable = product.StockAvailable;

            existingProduct.UpdatedAt = DateTime.UtcNow;
            
            await _db.SaveChangesAsync();
            
            return existingProduct;
        }
    }
}
