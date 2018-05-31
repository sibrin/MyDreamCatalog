using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Actions.CatalogManagment;
using Core.Models.Dto;
using Infrastructure;
using JetBrains.Annotations;
using NLog;

namespace Core
{
    public class CatalogService : DomainService
    {
        public CatalogService(IDbContext dbContext, ILogger logger)
            : base(dbContext, logger)
        {
        }

        public async Task<List<Catalog>> LoadCatalogsByParent([CanBeNull] int? parentId)
        {
            var action = new LoadCatalogsByParentAction(this.DbContext, this.Logger, parentId);

            return await this.ExecuteAction<LoadCatalogsByParentAction, List<Catalog>>(action);
        }
    }
}