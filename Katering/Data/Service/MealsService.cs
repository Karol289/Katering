using Katering.Entities;
using Microsoft.EntityFrameworkCore;
using Katering.Data.Food;

namespace Katering.Data.Service
{
    public class MealsService: KateringService
    {
        private readonly IDbContextFactory<KateringDbContext> _dbContextFactory;
        

        public MealsService(IDbContextFactory<KateringDbContext> dbContextFactory) : base(dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<List<Meal>> GetAllMealsAsync()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                // Fetch all meals from the database
                var meals = await context.Meals.ToListAsync();

                // Add a simple debug log to verify the meal count
                Console.WriteLine($"Fetched {meals.Count} meals from the database.");

                return meals;
            }
        }

    }
}
