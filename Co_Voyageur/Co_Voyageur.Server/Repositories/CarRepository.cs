using System.Linq.Expressions;
using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Repositories
{
    public class CarRepository : IRepository<Car, int>
    {
        public Task<Car?> Add(Car item)
        {
            throw new NotImplementedException();
        }
        public Task<Car?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Car?> GetByPredicate(Expression<Func<Car, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Car>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Car?> Update(int id, Car item)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
