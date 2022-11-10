using Joyeria.Core.Models;
using Joyeria.Core.Repositories;
using Joyeria.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly JoyeriaDbContext _dbContext;

        public ProductRepository(JoyeriaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Product> CreateAsync(Product productToCreate)
        {
            await _dbContext.Products.AddAsync(productToCreate);
            return productToCreate;
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            _dbContext.Products.Remove(product);
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            return product;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await this._dbContext.Products.ToListAsync();
        }

        public async Task<Product> UpdateAsync(Product productToUpdate)
        {
             _dbContext.Products.Update(productToUpdate);
            return await Task.FromResult(productToUpdate);
        }
    }
}
