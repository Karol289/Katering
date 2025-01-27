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

        // Pobierz posiłek na podstawie ID
        public async Task<Meal?> GetMealByIdAsync(int mealId)
        {
            using var context = _dbContext.CreateDbContext();
            return await context.Meals
                .Include(m => m.Diet)
                .Include(m => m.MealCategory)
                .FirstOrDefaultAsync(m => m.MealId == mealId);
        }

        // Zaktualizuj istniejący posiłek
        public async Task UpdateMealAsync(Meal updatedMeal)
        {
            using var context = _dbContext.CreateDbContext();

            // Znajdź istniejący rekord
            var existingMeal = await context.Meals
                .FirstOrDefaultAsync(m => m.MealId == updatedMeal.MealId);

            if (existingMeal == null)
            {
                throw new InvalidOperationException("Meal not found.");
            }

            // Zaktualizuj właściwości
            existingMeal.Name = updatedMeal.Name;
            existingMeal.Calories = updatedMeal.Calories;
            existingMeal.Price = updatedMeal.Price;
            existingMeal.Description = updatedMeal.Description;
            existingMeal.Diet = updatedMeal.Diet != null
                ? context.Diets.FirstOrDefault(d => d.DietId == updatedMeal.Diet.DietId)
                : null;
            existingMeal.MealCategory = updatedMeal.MealCategory != null
                ? context.MealCategories.FirstOrDefault(mc => mc.MealCategoryId == updatedMeal.MealCategory.MealCategoryId)
                : null;

            await context.SaveChangesAsync();
        }

        // Usuń posiłek na podstawie ID
        public async Task DeleteMealAsync(int mealId)
        {
            using var context = _dbContext.CreateDbContext();

            // Znajdź posiłek do usunięcia
            var mealToDelete = await context.Meals.FirstOrDefaultAsync(m => m.MealId == mealId);
            if (mealToDelete == null)
            {
                throw new InvalidOperationException("Meal not found.");
            }

            context.Meals.Remove(mealToDelete);
            await context.SaveChangesAsync();
        }

        public async Task<List<Meal>> GetMealsWithRatingsAsync()
        {
            using var context = _dbContext.CreateDbContext();
            return await context.Meals
                .Include(m => m.Ratings) // Załadowanie ocen
                .Include(m => m.Diet) // Załadowanie diety
                .Include(m => m.MealCategory) // Załadowanie kategorii
                .ToListAsync();
        }

    }
}
