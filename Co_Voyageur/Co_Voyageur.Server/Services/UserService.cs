using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Repositories;
using Co_Voyageur.Server.Services.Interfaces;

namespace Co_Voyageur.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User, int> _userRepository;

        public UserService(IUserRepository<User, int> userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<User> Create(User user)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetAll()
        {
           return  _userRepository.GetAll();
        }

        public Task<User?> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User?> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> Update(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
