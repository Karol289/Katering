using Katering.Data.Food;
using Katering.Entities;
using Microsoft.EntityFrameworkCore;

namespace Katering.Data.Service
{
    public class MealCategoryService : KateringService
    {
        public MealCategoryService(IDbContextFactory<KateringDbContext> dbContext) : base(dbContext)
        {
        }

        public async Task<List<MealCategory>> GetMealCategoriesAsync()
        {
            using var context = _dbContext.CreateDbContext();
            return await context.MealCategories.ToListAsync();
        }

        public async Task AddMealCategoryAsync(MealCategory category)
        {
            using var context = _dbContext.CreateDbContext();
            context.MealCategories.Add(category);
            await context.SaveChangesAsync();
        }

        public async Task UpdateMealCategoryAsync(MealCategory category)
        {
            using var context = _dbContext.CreateDbContext();
            var existingCategory = await context.MealCategories.FindAsync(category.MealCategoryId);
            if (existingCategory != null)
            {
                existingCategory.Name = category.Name;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteMealCategoryAsync(int categoryId)
        {
            using var context = _dbContext.CreateDbContext();
            var category = await context.MealCategories.FindAsync(categoryId);
            if (category != null)
            {
                context.MealCategories.Remove(category);
                await context.SaveChangesAsync();
            }
        }
    }
}
