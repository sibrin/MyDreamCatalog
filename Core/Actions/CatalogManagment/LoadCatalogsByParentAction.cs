using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Models.Dto;
using Core.Providers;
using Infrastructure;
using NLog;

namespace Core.Actions.CatalogManagment
{
    internal class LoadCatalogsByParentAction : ActionBase<List<Catalog>>
    {
        private readonly int? catalogId;

        private readonly CatalogCachedDataProvider provider;

        public LoadCatalogsByParentAction(IDbContext dbContext, ILogger logger, int? catalogId)
            : base(dbContext, logger)
        {
            this.catalogId = catalogId;
            this.provider = new CatalogCachedDataProvider(dbContext);
        }

        public override async Task<List<Catalog>> Do()
        {
            List<Infrastructure.Models.Catalog> dbCatalogs = await this.provider.LoadByParent(this.catalogId);

            List<Catalog> catalogs = dbCatalogs.Select(
                                                   async catalog => new Catalog
                                                   {
                                                       Id = catalog.Id,
                                                       ParentId = catalog.Parent.Id,
                                                       Name = catalog.Name,
                                                       HasChilds = (await this.provider.LoadByParent(catalog.Id)).Any()
                                                   })
                                               .Select(catalog => catalog.Result)
                                               .ToList();

            return catalogs;
        }
    }
}