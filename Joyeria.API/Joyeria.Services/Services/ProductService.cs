using Joyeria.Core;
using Joyeria.Core.Models;
using Joyeria.Core.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.Services.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Product> CreateAsync(Product productToCreate)
        {
            await _unitOfWork.Products.CreateAsync(productToCreate);
            await _unitOfWork.SaveChangesAsync();

            return productToCreate;
        }

        public async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.Products.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _unitOfWork.Products.GetProductByIdAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await this._unitOfWork.Products.GetProductsAsync();
        }

        public async Task<Product> UpdateAsync(Product productToUpdate)
        {
            await _unitOfWork.Products.UpdateAsync(productToUpdate);
            await _unitOfWork.SaveChangesAsync();

            return productToUpdate;
        }
    }
}
