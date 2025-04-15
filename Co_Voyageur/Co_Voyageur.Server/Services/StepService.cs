using System.Linq.Expressions;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Repositories;
using Co_Voyageur.Server.Services.Interfaces;

namespace Co_Voyageur.Server.Services;

public class StepService : IService<Step, int>
{
    private readonly IRepository<Step, int> _repository;

    public StepService(IRepository<Step, int> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Step>> GetAll() { return await _repository.GetAll(); }

    public async Task<Step?> GetById(int id) { return await _repository.GetById(id); }

    public async Task<Step?> GetByPredicate(Expression<Func<Step,bool>> predicate)
    {
        return await _repository.GetByPredicate(predicate);
    }

    public async Task<Step> Create(Step item) { return await _repository.Add(item); }

    public async Task<Step> Update(int id, Step item)
    {
        var oldItem = await _repository.GetById(id);
        if (oldItem == null)
            return null;

        if (oldItem.Departure!=item.Departure)
            oldItem.Departure = item.Departure;

        if (oldItem.Arrival != item.Arrival)
            oldItem.Arrival = item.Arrival;
        if (oldItem.Date != item.Date)
            oldItem.Date = item.Date;
        if(oldItem.Trip!=item.Trip)
            oldItem.Trip = item.Trip;

        return await _repository.Update(oldItem);
    }

    public async Task Delete(int id) { await _repository.Delete(id); }
}