using Katering.Data;
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

        // dodawanie kolejnych tablic !!
    }
}
