using System.Linq.Expressions;
using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Models;
using Microsoft.EntityFrameworkCore;

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
            await _appDbContext.Users.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<User?> GetById(int id)
        {
            return await _appDbContext.Users
        .Include(u => u.Trips)
            .ThenInclude(t => t.Steps)
        .Include(u => u.Trips)
            .ThenInclude(t => t.Users) // les passagers
        .Include(u => u.Reviews)
        .FirstOrDefaultAsync(u => u.Id == id);
        }
        public async Task<User?> GetByPredicate(Expression<Func<User, bool>> predicate)
        {
            return await _appDbContext.Users.FirstOrDefaultAsync(predicate);
        }
        public Task<IEnumerable<User>> GetAll()
        {
            return Task.FromResult<IEnumerable<User>>(_appDbContext.Users.Include(u => u.Trips)
            .ThenInclude(t => t.Steps)
        .Include(u => u.Trips)
            .ThenInclude(t => t.Users) // les passagers
        .Include(u => u.Reviews));
        }
        public async Task<User?> Update(User item)
        {
            if(_appDbContext.Entry(item).State is not EntityState.Modified)
                return null;
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        
        public async Task<bool> Delete(int id)
        {
            var user = await GetById(id);
            
            if (user is null)
                return false;

            _appDbContext.Users.Remove(user);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
