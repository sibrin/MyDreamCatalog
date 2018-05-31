using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public interface IDbContext
    {
        DbSet<Catalog> Catalogs { get; set; }

        DbSet<Product> Products { get; set; }
    }
}