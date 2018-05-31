using System.Threading.Tasks;

namespace Core.Actions
{
    public interface IAction
    {
        Task Do();
    }

    public interface IAction<T>
    {
        Task<T> Do();
    }
}