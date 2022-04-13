using Microsoft.EntityFrameworkCore;
using Skateshop.Models;

namespace Skateshop.Data
{
    public class SkateshopContext : DbContext
    {
        public SkateshopContext(DbContextOptions<SkateshopContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; }

        public DbSet<DeckProduct> DeckProduct { get; set; }

        public DbSet<Skateshop.Models.TrucksProduct> TrucksProduct { get; set; }
    }
}
