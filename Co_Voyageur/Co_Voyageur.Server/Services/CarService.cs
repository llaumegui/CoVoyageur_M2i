using System.Linq.Expressions;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Repositories;
using Co_Voyageur.Server.Services.Interfaces;
namespace Co_Voyageur.Server.Services;

public class CarService : IService<Car,int>
{
    private readonly IRepository<Car, int> _repository;

    public CarService(IRepository<Car, int> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Car>> GetAll() { return await _repository.GetAll(); }

    public async Task<Car?> GetById(int id) { return await _repository.GetById(id); }

    public async Task<Car?> GetByPredicate(Expression<Func<Car,bool>> predicate)
    {
        return await _repository.GetByPredicate(predicate);
    }

    public async Task<Car> Create(Car item) { return await _repository.Add(item); }

    public async Task<Car> Update(int id, Car item)
    {
        var oldItem = await _repository.GetById(id);
        if (oldItem == null)
            return null;
        
        if(oldItem.Model != item.Model)
            oldItem.Model = item.Model;
        if(oldItem.PassengerSize != item.PassengerSize)
            oldItem.PassengerSize = item.PassengerSize;
        if(oldItem.Color != item.Color)
            oldItem.Color = item.Color;
        if(oldItem.Plate != item.Plate)
            oldItem.Plate = item.Plate;
        if(oldItem.User != item.User)
            oldItem.User = item.User;

        return await _repository.Update(oldItem);
    }

    public async Task Delete(int id) { await _repository.Delete(id); }
}