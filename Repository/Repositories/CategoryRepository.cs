using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        public async Task<Category> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return await _appDbContext.Categories.Include(c => c.Products).Where(c=>c.Id == categoryId).SingleOrDefaultAsync();
        }
    }
}
