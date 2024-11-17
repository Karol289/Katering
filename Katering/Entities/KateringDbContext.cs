using Microsoft.EntityFrameworkCore;

namespace Katering.Entities
{
    public class KateringDbContext : DbContext
    {
        public KateringDbContext(DbContextOptions<KateringDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        // dodawanie kolejnych tablic !!
    }
}
