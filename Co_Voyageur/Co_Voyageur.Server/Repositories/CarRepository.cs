using System.Linq.Expressions;
using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Co_Voyageur.Server.Repositories
{
    public class CarRepository : IRepository<Car, int>
    {
        private readonly AppDbContext _appDbContext;

        public CarRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Car?> Add(Car item)
        {
            await _appDbContext.Cars.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Car?> GetById(int id)
        {
            return await _appDbContext.Cars.FindAsync(id);
        }
        public async Task<Car?> GetByPredicate(Expression<Func<Car, bool>> predicate)
        {
            return await _appDbContext.Cars.FirstOrDefaultAsync(predicate);
        }
        public Task<IEnumerable<Car>> GetAll()
        {
            return Task.FromResult<IEnumerable<Car>>(_appDbContext.Cars);
        }
        public async Task<Car?> Update(Car item)
        {
            if(_appDbContext.Entry(item).State is not EntityState.Modified)
                return null;
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        
        public async Task<bool> Delete(int id)
        {
            var car = await GetById(id);
            
            if (car is null)
                return false;

            _appDbContext.Cars.Remove(car);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
