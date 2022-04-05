using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Skateshop.Models;

namespace Skateshop.Data
{
    public class SkateshopContext : DbContext
    {
        public SkateshopContext (DbContextOptions<SkateshopContext> options)
            : base(options)
        {
        }

        public DbSet<Skateshop.Models.User> User { get; set; }
    }
}
