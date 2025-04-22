using System.Linq.Expressions;
using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Co_Voyageur.Server.Repositories
{
    public class TripRepository : IRepository<Trip, int>
    {
        private readonly AppDbContext _appDbContext;

        public TripRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Trip?> Add(Trip item)
        {
            await _appDbContext.Trips.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Trip?> GetById(int id)
        {
            return await _appDbContext.Trips.Include(c => c.Driver).Include(c => c.Users).Include(c => c.Steps).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Trip?> GetByPredicate(Expression<Func<Trip, bool>> predicate)
        {
            return await _appDbContext.Trips.FirstOrDefaultAsync(predicate);
        }
        public Task<IEnumerable<Trip>> GetAll()
        {
            return Task.FromResult<IEnumerable<Trip>>(_appDbContext.Trips.Include(c => c.Driver).Include(c => c.Users).Include(c => c.Steps));
        }
        public async Task<Trip?> Update(Trip item)
        {
            if(_appDbContext.Entry(item).State is not EntityState.Modified)
                return null;
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        
        public async Task<bool> Delete(int id)
        {
            var trip = await GetById(id);
            
            if (trip is null)
                return false;

            _appDbContext.Trips.Remove(trip);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
