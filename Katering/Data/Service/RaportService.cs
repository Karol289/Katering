﻿using Katering.Data.Food;
using Katering.Data.Users;
using Katering.Data.Orders;
using Katering.Entities;
using Microsoft.EntityFrameworkCore;

namespace Katering.Data.Service
{
    public class RaportService : KateringService
    {
        private readonly IDbContextFactory<KateringDbContext> dbContext;

        public RaportService(IDbContextFactory<KateringDbContext> dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<Meal> GetAllMeals()
        {
            using (var context = dbContext.CreateDbContext())
            {
                return context.Meals.ToList();
            }
        }


        public List<Order> GetAllUserOrders(int userId)
        {
            using (var context = dbContext.CreateDbContext())
            {
                return context.Orders
                              .Where(order => order.User.Id == userId)
                              .ToList();
            }
        }


        public List<MealCategory> GetAllMealCategories()
        {
            using (var context = dbContext.CreateDbContext())
            {
                return context.MealCategories.ToList();
            }
        }




    }
}

