using System.Linq.Expressions;
using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Repositories
{
    public class UserRepository : IRepository<User, int>
    {

        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<User?> Add(User item)
        {
            throw new NotImplementedException();
        }
        public async Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<User?> GetByPredicate(Expression<Func<User, bool>> predicate)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<User>> GetAll()
        {
            return Task.FromResult<IEnumerable<User>>(_appDbContext.Users);
        }
        public async Task<User?> Update(int id, User item)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
