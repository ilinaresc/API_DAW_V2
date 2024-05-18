using API_DAW_DOMAIN.Core.Entities;
using API_DAW_DOMAIN.Core.Interfaces;
using API_DAW_DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_DAW_DOMAIN.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DbDawContext _dbContext;

        public CategoryRepository(DbDawContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _dbContext
                .Category
                .Where(cat => cat.IsActive == true)
                .ToListAsync();
        }

        public async Task<Category> GetById(int id)
        {
            return await _dbContext
                .Category
                .Where(cat => cat.IsActive == true && cat.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> Insert(Category category)
        {
            await _dbContext.Category.AddAsync(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Update(Category category)
        {
            _dbContext.Category.Update(category);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var findCategory = await _dbContext.Category.Where(cat => cat.IsActive == true && cat.Id == id).FirstOrDefaultAsync();

            if (findCategory != null)
            {
                return false;
            }

            _dbContext.Category.Remove(findCategory);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> DeleteLogic(int id)
        {
            var findCategory = await _dbContext.Category.Where(cat => cat.IsActive == true && cat.Id == id).FirstOrDefaultAsync();

            if (findCategory != null)
            {
                return false;
            }

            findCategory.IsActive = false;
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }
    }
}
