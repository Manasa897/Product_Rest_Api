using Microsoft.EntityFrameworkCore;
using Product_Rest_Api.Data;
using Product_Rest_Api.Models;
using System.Runtime.CompilerServices;

namespace Product_Rest_Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
        public async Task<Product> GetProductById(int id)
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return product;
        }
        public async Task DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
                if(product !=null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

    }
}

