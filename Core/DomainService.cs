using System.Threading.Tasks;
using Core.Actions;
using Infrastructure;
using NLog;

namespace Core
{
    public abstract class DomainService
    {
        protected readonly ILogger Logger;

        protected DomainService(IDbContext dbContext, ILogger logger)
        {
            this.Logger = logger;
            this.DbContext = dbContext;
        }

        protected IDbContext DbContext { get; }

        protected internal Task ExecuteAction<T>(T action)
            where T : IAction
        {
            return action.Do();
        }

        protected internal Task<TResult> ExecuteAction<T, TResult>(T action)
            where T : IAction<TResult>
        {
            return action.Do();
        }
    }
}