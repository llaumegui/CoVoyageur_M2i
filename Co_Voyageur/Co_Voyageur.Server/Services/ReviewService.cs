using System.Linq.Expressions;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Repositories;
using Co_Voyageur.Server.Services.Interfaces;

namespace Co_Voyageur.Server.Services;

public class ReviewService : IService<Review, int>
{
    private readonly IRepository<Review, int> _repository;

    public ReviewService(IRepository<Review, int> repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Review>> GetAll() { return await _repository.GetAll(); }

    public async Task<Review?> GetById(int id) { return await _repository.GetById(id); }

    public async Task<Review?> GetByPredicate(Expression<Func<Review,bool>> predicate)
    {
        return await _repository.GetByPredicate(predicate);
    }

    public async Task<Review> Create(Review item) { return await _repository.Add(item); }

    public async Task<Review> Update(int id, Review item)
    {
        var oldItem = await _repository.GetById(id);
        if (oldItem == null)
            return null;
        
        if(oldItem.Comment != item.Comment)
            oldItem.Comment = item.Comment;
        if(oldItem.Rate != item.Rate)
            oldItem.Rate = item.Rate;
        if(oldItem.User!=item.User)
            oldItem.User = item.User;

        return await _repository.Update(oldItem);
    }

    public async Task Delete(int id) { await _repository.Delete(id); }
}