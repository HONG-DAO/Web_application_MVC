using MyStore.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task SaveProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);

        // Thêm phương thức kiểm tra sự tồn tại của sản phẩm
        Task<bool> ProductExistsAsync(int productId);
    }
}

