using System.Linq.Expressions;
using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Repositories
{
    public class ReviewRepository : IRepository<Review, int>
    {
        public Task<Review?> Add(Review item)
        {
            throw new NotImplementedException();
        }
        public Task<Review?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Review?> GetByPredicate(Expression<Func<Review, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Review>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Review?> Update(int id, Review item)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
