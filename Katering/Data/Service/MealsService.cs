using Katering.Entities;
using Microsoft.EntityFrameworkCore;
using Katering.Data.Food;

namespace Katering.Data.Service
{
    public class MealsService: KateringService
    {
        // Konstruktor przekazuje zależności do bazy danych
        public MealsService(IDbContextFactory<KateringDbContext> dbContext) : base(dbContext)
        {
        }

        public async Task<List<Diet>> GetDietsAsync()
        {
            using var context = _dbContext.CreateDbContext(); // Tworzenie kontekstu z fabryki
            return await context.Diets.ToListAsync(); // Pobranie wszystkich rekordów z tabeli "Diets"
        }

        public async Task<List<MealCategory>> GetMealCategoriesAsync()
        {
            using var context = _dbContext.CreateDbContext(); // Tworzenie kontekstu z fabryki
            return await context.MealCategories.ToListAsync(); // Pobranie wszystkich rekordów z tabeli "MealCategories"
        }

        public async Task AddMealAsync(Meal meal)
        {
            using var context = _dbContext.CreateDbContext(); // Tworzenie kontekstu z fabryki
            context.Meals.Add(meal); // Dodanie posiłku do tabeli "Meals"
            await context.SaveChangesAsync(); // Zapisanie zmian w bazie danych
        }

        public async Task<List<Meal>> GetMealsAsync()
        {
            using var context = _dbContext.CreateDbContext(); // Tworzenie kontekstu z fabryki
            return await context.Meals.ToListAsync(); // Pobranie wszystkich rekordów z tabeli "MealCategories"
        }
    }
}
