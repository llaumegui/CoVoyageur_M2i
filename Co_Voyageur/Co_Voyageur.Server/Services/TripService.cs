using System.Linq.Expressions;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Repositories;
using Co_Voyageur.Server.Services.Interfaces;

namespace Co_Voyageur.Server.Services;

public class TripService : IService<Trip,int>
{
    private readonly IRepository<Trip, int> _repository;

    public TripService(IRepository<Trip, int> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Trip>> GetAll() { return await _repository.GetAll(); }

    public async Task<Trip?> GetById(int id) { return await _repository.GetById(id); }

    public async Task<Trip?> GetByPredicate(Expression<Func<Trip,bool>> predicate)
    {
        return await _repository.GetByPredicate(predicate);
    }

    public async Task<Trip> Create(Trip item) { return await _repository.Add(item); }

    public async Task<Trip> Update(int id, Trip item)
    {
        var oldItem = await _repository.GetById(id);
        if (oldItem == null)
            return null;
        
        if(oldItem.DriverId != item.DriverId)
            oldItem.DriverId = item.DriverId;
        if(oldItem.Price != item.Price)
            oldItem.Price = item.Price;
        if(!oldItem.Steps.Equals(item.Steps))
            oldItem.Steps = item.Steps;
        if(!oldItem.Users.Equals(item.Users))
            oldItem.Users = item.Users;

        return await _repository.Update(oldItem);
    }

    public async Task Delete(int id) { await _repository.Delete(id); }
}