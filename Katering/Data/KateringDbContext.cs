using Katering.Data;
using Katering.Data.Food;
using Katering.Data.Order;
using Katering.Data.Users;
using Katering.Migrations;
using Microsoft.EntityFrameworkCore;

namespace Katering.Entities
{
    public class KateringDbContext : DbContext
    {
        public KateringDbContext(DbContextOptions<KateringDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        public DbSet<Moderator> Moderators { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<Contractor> Contractors { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        public DbSet<Diet> Diets { get; set; }

        public DbSet<Meal> Meals { get; set; }

        public DbSet<MealCategory> MealCategories { get; set; }

        public DbSet<Rating> Ratings { get; set; }

        public DbSet<Subscription> Subscriptions { get; set; }
   
        public DbSet<Order> Orders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        // dodawanie kolejnych tablic !!
    }
}
