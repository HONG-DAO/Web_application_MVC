using MyStore.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Business;
using System.Linq;

namespace MyStore.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyStoreDbContext _context;

        public ProductRepository(MyStoreDbContext context)
        {
            _context = context;
        }

        // Lấy tất cả sản phẩm
        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                return await _context.Products.Include(f => f.Category).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving the products: {e.Message}");
            }
        }

        // Lưu một sản phẩm mới
        public async Task SaveProductAsync(Product p)
        {
            try
            {
                _context.Products.Add(p);
                await _context.SaveChangesAsync(); // Cập nhật cơ sở dữ liệu
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while saving the product: {e.Message}");
            }
        }

        // Cập nhật một sản phẩm
        public async Task UpdateProductAsync(Product p)
        {
            try
            {
                _context.Entry(p).State = EntityState.Modified;
                await _context.SaveChangesAsync(); // Cập nhật cơ sở dữ liệu
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while updating the product: {e.Message}");
            }
        }

        // Xóa một sản phẩm
        public async Task DeleteProductAsync(Product p)
        {
            try
            {
                var productToDelete = await _context.Products
                    .SingleOrDefaultAsync(c => c.ProductId == p.ProductId);

                if (productToDelete != null)
                {
                    _context.Products.Remove(productToDelete);
                    await _context.SaveChangesAsync(); // Xóa sản phẩm khỏi cơ sở dữ liệu
                }
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while deleting the product: {e.Message}");
            }
        }

        // Lấy một sản phẩm theo ID
        public async Task<Product> GetProductByIdAsync(int id)
        {
            try
            {
                return await _context.Products
                    .FirstOrDefaultAsync(c => c.ProductId == id);
            }
            catch (Exception e)
            {
                throw new Exception($"An error occurred while retrieving the product by ID: {e.Message}");
            }
        }
    }
}
