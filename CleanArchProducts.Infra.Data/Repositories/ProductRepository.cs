using System.Collections.Generic;
using System.Threading.Tasks;
using CleanArchProducts.Domain.Entities;
using CleanArchProducts.Domain.Interfaces;
using CleanArchProducts.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CleanArchProducts.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _productContext;
        public ProductRepository(ApplicationDbContext context)
        {
            _productContext = context;
        }
        public async Task<Product> CreateAsync(Product product)
        {
           _productContext.Add(product);
           await _productContext.SaveChangesAsync();
           return product;
        }

        public async Task<Product> DeleteAsync(Product product)
        {
            _productContext.Remove(product);
           await _productContext.SaveChangesAsync();
           return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.Include(product => product.Category).SingleOrDefaultAsync(product => product.Id == id);
        }
        
        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
           await _productContext.SaveChangesAsync();
           return product;
        }
    }
}