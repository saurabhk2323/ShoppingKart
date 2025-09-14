using AutoMapper;
using InventoryManagement.Contracts;
using InventoryManagement.DTOs;
using InventoryManagement.Entities;
using InventoryManagement.Services;
using Microsoft.Extensions.Logging;
using Moq;

namespace InventoryManagementTest
{
    public class ProductsServiceTests
    {
        private readonly Mock<ILogger<ProductsService>> _mockLogger;
        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IProductsRepository> _mockRepository;
        private readonly ProductsService _service;

        public ProductsServiceTests()
        {
            _mockLogger = new Mock<ILogger<ProductsService>>();
            _mockMapper = new Mock<IMapper>();
            _mockRepository = new Mock<IProductsRepository>();
            _service = new ProductsService(_mockLogger.Object, _mockMapper.Object, _mockRepository.Object);
        }

        #region CreateProduct Tests

        [Fact]
        public async Task CreateProduct_ValidInput_ReturnsResponseProductDto()
        {
            // Arrange
            var createProductDto = new CreateProductDto
            {
                Name = "Test Product",
                Description = "Test Description",
                Price = 99.99m,
                AvailableStocks = 10,
                Category = "TestCategory"
            };

            var product = new Product
            {
                Id = 123456,
                Name = "Test Product",
                Description = "Test Description",
                Price = 99.99m,
                StockAvailable = 10,
                Category = "TestCategory"
            };

            var expectedResponse = new ResponseProductDto
            {
                Id = 123456,
                Name = "Test Product",
                Description = "Test Description",
                Price = 99.99m,
                StockAvailable = 10,
                Category = "TestCategory"
            };

            _mockMapper.Setup(m => m.Map<Product>(createProductDto)).Returns(product);
            _mockMapper.Setup(m => m.Map<ResponseProductDto>(product)).Returns(expectedResponse);
            _mockRepository.Setup(r => r.AddAsync(product)).Returns(Task.CompletedTask);

            // Act
            var result = await _service.CreateProduct(createProductDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Id, result.Id);
            Assert.Equal(expectedResponse.Name, result.Name);
            Assert.Equal(expectedResponse.Price, result.Price);
            Assert.Equal(expectedResponse.StockAvailable, result.StockAvailable);
            Assert.Equal(expectedResponse.Category, result.Category);
        }

        #endregion

        #region GetProduct Tests

        [Fact]
        public async Task GetProduct_ExistingProduct_ReturnsResponseProductDto()
        {
            // Arrange
            var productId = 123456;
            var product = new Product
            {
                Id = productId,
                Name = "Test Product",
                Price = 99.99m,
                StockAvailable = 10,
                Category = "TestCategory"
            };

            var expectedResponse = new ResponseProductDto
            {
                Id = productId,
                Name = "Test Product",
                Price = 99.99m,
                StockAvailable = 10,
                Category = "TestCategory"
            };

            _mockRepository.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);
            _mockMapper.Setup(m => m.Map<ResponseProductDto>(product)).Returns(expectedResponse);

            // Act
            var result = await _service.GetProduct(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Id, result.Id);
            Assert.Equal(expectedResponse.Name, result.Name);
            Assert.Equal(expectedResponse.StockAvailable, result.StockAvailable);
        }

        [Fact]
        public async Task GetProduct_NonExistingProduct_ReturnsNull()
        {
            // Arrange
            var productId = 999999;
            _mockRepository.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync((Product?)null);

            // Act
            var result = await _service.GetProduct(productId);

            // Assert
            Assert.Null(result);
        }

        #endregion

        #region GetProducts Tests

        [Fact]
        public async Task GetProducts_ReturnsAllProducts()
        {
            // Arrange
            var products = new List<Product>
            {
                new Product { Id = 123456, Name = "Product 1", Price = 10.00m, StockAvailable = 5, Category = "TestCategory" },
                new Product { Id = 234567, Name = "Product 2", Price = 20.00m, StockAvailable = 15, Category = "TestCategory" }
            };

            var expectedResponses = new List<ResponseProductDto>
            {
                new ResponseProductDto { Id = 123456, Name = "Product 1", Price = 10.00m, StockAvailable = 5, Category = "TestCategory" },
                new ResponseProductDto { Id = 234567, Name = "Product 2", Price = 20.00m, StockAvailable = 15, Category = "TestCategory" }
            };

            _mockRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(products);
            _mockMapper.Setup(m => m.Map<ResponseProductDto>(products[0])).Returns(expectedResponses[0]);
            _mockMapper.Setup(m => m.Map<ResponseProductDto>(products[1])).Returns(expectedResponses[1]);

            // Act
            var result = await _service.GetProducts();

            // Assert
            Assert.NotNull(result);
            var resultList = result.ToList();
            Assert.Equal(2, resultList.Count);
            Assert.Equal(expectedResponses[0].Id, resultList[0].Id);
            Assert.Equal(expectedResponses[1].Id, resultList[1].Id);
        }

        #endregion

        #region UpdateProduct Tests

        [Fact]
        public async Task UpdateProduct_ExistingProduct_ReturnsUpdatedProduct()
        {
            // Arrange
            var productId = 123456;
            var updateProductDto = new UpdateProductDto
            {
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 199.99m,
                StockAvailable = 20,
                Category = "TestCategory"
            };

            var mappedProduct = new Product
            {
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 199.99m,
                StockAvailable = 20,
                Category = "TestCategory"
            };

            var updatedProduct = new Product
            {
                Id = productId,
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 199.99m,
                StockAvailable = 20,
                Category = "TestCategory"
            };

            var expectedResponse = new ResponseProductDto
            {
                Id = productId,
                Name = "Updated Product",
                Description = "Updated Description",
                Price = 199.99m,
                StockAvailable = 20,
                Category = "TestCategory"
            };

            _mockMapper.Setup(m => m.Map<Product>(updateProductDto)).Returns(mappedProduct);
            _mockRepository.Setup(r => r.UpdateAsync(productId, mappedProduct)).ReturnsAsync(updatedProduct);
            _mockMapper.Setup(m => m.Map<ResponseProductDto>(updatedProduct)).Returns(expectedResponse);

            // Act
            var result = await _service.UpdateProduct(productId, updateProductDto);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedResponse.Id, result.Id);
            Assert.Equal(expectedResponse.Name, result.Name);
            Assert.Equal(expectedResponse.Price, result.Price);
        }

        #endregion

        #region DeleteProduct Tests

        [Fact]
        public async Task DeleteProduct_ExistingProduct_ReturnsTrue()
        {
            // Arrange
            var productId = 123456;
            _mockRepository.Setup(r => r.DeleteAsync(productId)).ReturnsAsync(true);

            // Act
            var result = await _service.DeleteProduct(productId);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteProduct_NonExistingProduct_ReturnsFalse()
        {
            // Arrange
            var productId = 999999;
            _mockRepository.Setup(r => r.DeleteAsync(productId)).ReturnsAsync(false);

            // Act
            var result = await _service.DeleteProduct(productId);

            // Assert
            Assert.False(result);
        }

        #endregion

        #region DecrementStock Tests

        [Fact]
        public async Task DecrementStock_SufficientStock_ReturnsTrue()
        {
            // Arrange
            var productId = 123456;
            var quantity = 5;
            var product = new Product
            {
                Id = productId,
                Name = "Test Product",
                StockAvailable = 10
            };

            _mockRepository.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);
            _mockRepository.Setup(r => r.UpdateAsync(productId, product)).ReturnsAsync(product);

            // Act
            var result = await _service.DecrementStock(productId, quantity);

            // Assert
            Assert.True(result);
            Assert.Equal(5, product.StockAvailable); // 10 - 5
        }

        [Fact]
        public async Task DecrementStock_InsufficientStock_ReturnsFalse()
        {
            // Arrange
            var productId = 123456;
            var quantity = 15;
            var product = new Product
            {
                Id = productId,
                Name = "Test Product",
                StockAvailable = 10
            };

            _mockRepository.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);
            _mockRepository.Setup(r => r.UpdateAsync(productId, product)).ReturnsAsync(product);

            // Act
            var result = await _service.DecrementStock(productId, quantity);

            // Assert
            Assert.False(result);
            Assert.Equal(10, product.StockAvailable); // Stock should remain unchanged
        }

        [Fact]
        public async Task DecrementStock_ExactStock_ReturnsTrue()
        {
            // Arrange
            var productId = 123456;
            var quantity = 10;
            var product = new Product
            {
                Id = productId,
                Name = "Test Product",
                StockAvailable = 10
            };

            _mockRepository.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync(product);
            _mockRepository.Setup(r => r.UpdateAsync(productId, product)).ReturnsAsync(product);

            // Act
            var result = await _service.DecrementStock(productId, quantity);

            // Assert
            Assert.True(result);
            Assert.Equal(0, product.StockAvailable);
        }

        [Fact]
        public async Task DecrementStock_NonExistingProduct_ReturnsFalse()
        {
            // Arrange
            var productId = 999999;
            var quantity = 5;
            _mockRepository.Setup(r => r.GetByIdAsync(productId)).ReturnsAsync((Product?)null);

            // Act
            var result = await _service.DecrementStock(productId, quantity);

            // Assert
            Assert.False(result);
        }

        #endregion
    }
}