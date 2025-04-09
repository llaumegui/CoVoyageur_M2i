using System.Linq.Expressions;

namespace Co_Voyageur.Server.Repositories
{
    public interface IRepository<T, Tid> where T : new()
    {
        Task<T?> Add(T item);
        Task<T?> GetById(Tid id);
        Task<T?> GetByPredicate(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        Task<T?> Update(Tid id, T item);
        Task<bool> Delete(Tid id);
    }
}
