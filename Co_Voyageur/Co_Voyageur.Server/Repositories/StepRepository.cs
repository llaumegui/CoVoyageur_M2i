using System.Linq.Expressions;
using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Co_Voyageur.Server.Repositories
{
    public class StepRepository : IRepository<Step, int>
    {
        private readonly AppDbContext _appDbContext;

        public StepRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Step?> Add(Step item)
        {
            await _appDbContext.Steps.AddAsync(item);
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        public async Task<Step?> GetById(int id)
        {
            return await _appDbContext.Steps.Include(c => c.Trip).FirstOrDefaultAsync(c => c.Id == id);
        }
        public async Task<Step?> GetByPredicate(Expression<Func<Step, bool>> predicate)
        {
            return await _appDbContext.Steps.FirstOrDefaultAsync(predicate);
        }
        public Task<IEnumerable<Step>> GetAll()
        {
            return Task.FromResult<IEnumerable<Step>>(_appDbContext.Steps.Include(c=> c.Trip));
        }
        public async Task<Step?> Update(Step item)
        {
            if(_appDbContext.Entry(item).State is not EntityState.Modified)
                return null;
            await _appDbContext.SaveChangesAsync();
            return item;
        }
        
        public async Task<bool> Delete(int id)
        {
            var step = await GetById(id);
            
            if (step is null)
                return false;

            _appDbContext.Steps.Remove(step);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
    }
}
