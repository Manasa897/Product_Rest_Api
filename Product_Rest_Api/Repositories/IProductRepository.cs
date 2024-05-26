using Product_Rest_Api.Models;

namespace Product_Rest_Api.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();
        Task<Product> GetProductById(int id);
        Task<Product>AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task DeleteProduct(int id);
    }
}
