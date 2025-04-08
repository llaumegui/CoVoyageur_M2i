using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAll();
        Task<User?> GetById(int id);
        Task<User?> GetByEmail(string email);
        Task<User> Create(User user);
        Task<User> Update(int id, User user);
        Task Delete(int id);
    }
}
