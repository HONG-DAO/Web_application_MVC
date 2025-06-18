using MyStore.Business;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyStore.IRepository
{
    public interface IProductRepository
    {
        // Lấy tất cả sản phẩm
        Task<List<Product>> GetProductsAsync();

        // Lấy sản phẩm theo ID
        Task<Product> GetProductByIdAsync(int id);

        // Lưu một sản phẩm mới
        Task SaveProductAsync(Product product);

        // Cập nhật thông tin sản phẩm
        Task UpdateProductAsync(Product product);

        // Xóa sản phẩm
        Task DeleteProductAsync(Product product);
    }
}
