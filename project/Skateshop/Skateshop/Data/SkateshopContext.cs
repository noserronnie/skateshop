﻿using Microsoft.EntityFrameworkCore;
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

        public DbSet<TrucksProduct> TrucksProduct { get; set; }

        public DbSet<WheelsProduct> WheelsProduct { get; set; }

        public DbSet<GriptapeProduct> GriptapeProduct { get; set; }

        public DbSet<Brand> Brand { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }
    }
}
