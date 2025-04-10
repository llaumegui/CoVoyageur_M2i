using System.Linq.Expressions;
using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Co_Voyageur.Server.Repositories
{
    public class ReviewRepository : IRepository<Review, int>
    {
        private readonly AppDbContext _appDbContext;

        public ReviewRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Review?> Add(Review item)
        {
            await _appDbContext.Reviews.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Review?> GetById(int id)
        {
            return await _appDbContext.Reviews.FindAsync(id);
        }
        public async Task<Review?> GetByPredicate(Expression<Func<Review, bool>> predicate)
        {
            return await _appDbContext.Reviews.FirstOrDefaultAsync(predicate);
        }
        public Task<IEnumerable<Review>> GetAll()
        {
            return Task.FromResult<IEnumerable<Review>>(_appDbContext.Reviews);
        }
        public async Task<Review?> Update(Review item)
        {
            if(_appDbContext.Entry(item).State is not EntityState.Modified)
                return null;
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        
        public async Task<bool> Delete(int id)
        {
            var review = await GetById(id);
            
            if (review is null)
                return false;

            _appDbContext.Reviews.Remove(review);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
