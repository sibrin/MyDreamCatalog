using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class DatabaseContext : DbContext, IDbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Catalog> Catalogs { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}