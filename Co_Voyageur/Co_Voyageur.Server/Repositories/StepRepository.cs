using System.Linq.Expressions;
using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Repositories
{
    public class StepRepository : IRepository<Step, int>
    {
        public Task<Step?> Add(Step item)
        {
            throw new NotImplementedException();
        }
        public Task<Step?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public Task<Step?> GetByPredicate(Expression<Func<Step, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<Step>> GetAll()
        {
            throw new NotImplementedException();
        }
        public Task<Step?> Update(int id, Step item)
        {
            throw new NotImplementedException();
        }
        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
