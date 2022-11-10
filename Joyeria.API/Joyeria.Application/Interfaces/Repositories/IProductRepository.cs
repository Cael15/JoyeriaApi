using Joyeria.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.Core.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(Guid id);
        Task<Product> UpdateAsync(Product productToUpdate);
        Task<Product> CreateAsync(Product productToCreate);
        Task DeleteAsync(Guid id);
    }
}
