using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;

namespace Core.Providers
{
    internal class CatalogCachedDataProvider
    {
        private static readonly IMemoryCache CatalogStorage;

        private static readonly IMemoryCache ProductCountsStorage;

        private readonly IDbContext dbContext;

        static CatalogCachedDataProvider()
        {
            CatalogStorage = new MemoryCache(
                new OptionsWrapper<MemoryCacheOptions>(
                    new MemoryCacheOptions
                    {
                        SizeLimit = 10
                    }));

            ProductCountsStorage = new MemoryCache(
                new OptionsWrapper<MemoryCacheOptions>(
                    new MemoryCacheOptions
                    {
                        SizeLimit = 100
                    }));
        }

        public CatalogCachedDataProvider(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Catalog>> LoadByParent(int? parent)
        {
            string key = parent == null
                ? "root"
                : parent.Value.ToString();

            return await CatalogStorage.GetOrCreateAsync(
                key,
                async entry =>
                {
                    return await this.dbContext.Catalogs
                                     .Include(catalog => catalog.Parent)
                                     .AsNoTracking()
                                     .Where(catalog => catalog.Parent.Id == parent)
                                     .ToListAsync();
                });
        }

        public async Task<int> LoadCountProducts(int catalogId)
        {
            return await ProductCountsStorage.GetOrCreateAsync(
                catalogId,
                async entry =>
                {
                    return await this.dbContext.Products
                                     .Include(product => product.Catalog)
                                     .CountAsync(product => product.Catalog.Id == catalogId);
                });
        }

        public void InvalidateCountProducts(int catalogId)
        {
            ProductCountsStorage.Remove(catalogId);
        }
    }
}