using System.Linq.Expressions;
namespace Co_Voyageur.Server.Services.Interfaces;

public interface IService<T,TData> where T : class
{
    Task<IEnumerable<T>> GetAll();
    Task<T?> GetById(TData id);
    Task<T?> GetByPredicate(Expression<Func<T, bool>> predicate);
    Task<T> Create(T item);
    Task<T> Update(TData id, T item);
    Task Delete(TData id);
    
}