using Katering.Data.Food;
using Katering.Entities;
using Microsoft.EntityFrameworkCore;

namespace Katering.Data.Service
{
    public class DietsService : KateringService
    {
        public DietsService(IDbContextFactory<KateringDbContext> dbContext) : base(dbContext)
        {
        }

        // Pobierz wszystkie diety
        public async Task<List<Diet>> GetDietsAsync()
        {
            using var context = _dbContext.CreateDbContext();
            return await context.Diets.ToListAsync();
        }

        // Dodaj dietę
        public async Task AddDietAsync(Diet diet)
        {
            using var context = _dbContext.CreateDbContext();
            context.Diets.Add(diet);
            await context.SaveChangesAsync();
        }

        // Edytuj dietę
        public async Task UpdateDietAsync(Diet diet)
        {
            using var context = _dbContext.CreateDbContext();
            var existingDiet = await context.Diets.FindAsync(diet.DietId);
            if (existingDiet != null)
            {
                existingDiet.Name = diet.Name;
                await context.SaveChangesAsync();
            }
        }

        // Usuń dietę
        public async Task DeleteDietAsync(int dietId)
        {
            using var context = _dbContext.CreateDbContext();
            var diet = await context.Diets.FindAsync(dietId);
            if (diet != null)
            {
                context.Diets.Remove(diet);
                await context.SaveChangesAsync();
            }
        }
    }
}
