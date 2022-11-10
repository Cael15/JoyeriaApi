using Joyeria.Core.Models;
using Joyeria.Core.Repositories;
using Joyeria.Data.Shared;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Joyeria.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly JoyeriaDbContext _dbContext;

        public CategoryRepository(JoyeriaDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<Category> CreateAsync(Category categoryToCreate)
        {
            await _dbContext.Categories.AddAsync(categoryToCreate);
            return categoryToCreate;
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await this._dbContext.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _dbContext.Categories.FindAsync(id);
            return category;
        }

        public  async Task<Category> UpdateAsync(Category categoryToUpdate)
        {
            _dbContext.Categories.Update(categoryToUpdate);
            return await Task.FromResult(categoryToUpdate);
        }
    }
}
