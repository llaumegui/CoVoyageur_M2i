using System.Linq.Expressions;
using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Repositories
{
    public class TripRepository : IRepository<Trip, int>
    {
        public Task<Trip?> Add(Trip item)
        {
            throw new NotImplementedException();
        }
        public Task<Trip?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Trip?> GetByPredicate(Expression<Func<Trip, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Trip>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Trip?> Update(int id, Trip item)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
