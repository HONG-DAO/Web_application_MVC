using MyStore.Business;
using MyStore.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> ProductExistsAsync(int productId)
        {
            var product = await _productRepository.GetProductByIdAsync(productId);
            return product != null;
        }
        // Lấy tất cả sản phẩm
        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await _productRepository.GetProductsAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving the products: {e.Message}");
            }
        }

        // Lấy sản phẩm theo ID
        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _productRepository.GetProductByIdAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving the product by ID: {e.Message}");
            }
        }

        // Lưu một sản phẩm mới
        public async Task SaveProductAsync(Product product)
        {
            try
            {
                await _productRepository.SaveProductAsync(product);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while saving the product: {e.Message}");
            }
        }

        // Cập nhật thông tin sản phẩm
        public async Task UpdateProductAsync(Product product)
        {
            try
            {
                await _productRepository.UpdateProductAsync(product);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while updating the product: {e.Message}");
            }
        }

        // Xóa sản phẩm
        public async Task DeleteProductAsync(Product product)
        {
            try
            {
                await _productRepository.DeleteProductAsync(product);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while deleting the product: {e.Message}");
            }
        }
    }
}
