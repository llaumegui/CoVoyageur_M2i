using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Repositories
{
    public class UserRepository : IUserRepository<User, int>
    {

        private readonly AppDbContext _appDbContext;

        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public User? Add(User item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetAll()
        {
            return _appDbContext.Users;
        }

        public User? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public User? Update(int id, User item)
        {
            throw new NotImplementedException();
        }
    }
}
