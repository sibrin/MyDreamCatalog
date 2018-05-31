using System.Threading.Tasks;
using Infrastructure;
using NLog;

namespace Core.Actions
{
    internal abstract class ActionBase : Action, IAction
    {
        protected ActionBase(IDbContext dbContext, ILogger logger)
            : base(dbContext, logger)
        {
        }

        public abstract Task Do();
    }

    internal abstract class ActionBase<T> : Action, IAction<T>
    {
        protected ActionBase(IDbContext dbContext, ILogger logger)
            : base(dbContext, logger)
        {
        }

        public abstract Task<T> Do();
    }

    internal abstract class Action
    {
        protected readonly IDbContext DbContext;
        protected readonly ILogger Logger;

        protected Action(IDbContext dbContext, ILogger logger)
        {
            this.DbContext = dbContext;
            this.Logger = logger;
        }
    }
}