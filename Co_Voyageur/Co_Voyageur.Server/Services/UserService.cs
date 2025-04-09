using Co_Voyageur.Server.Helpers;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Repositories;
using Co_Voyageur.Server.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace Co_Voyageur.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<User, int> _repository;
        private readonly AppSettings _appSettings;
        private readonly Encryptor _encryptor;
        

        public UserService(IRepository<User, int> repository, IOptions<AppSettings> appSettings)
        {
            _repository = repository;
            _appSettings = appSettings.Value;
            _encryptor = new();
        }

        public async Task<User> Create(User user) { return await _repository.Add(user); }

        public async Task Delete(int id) { await _repository.Delete(id); }

        public async Task<IEnumerable<User>> GetAll() { return await _repository.GetAll(); }

        public async Task<User?> GetByEmail(string email)
        {
            return await _repository.GetByPredicate(u => u.Email == email);
        }

        public async Task<User?> GetById(int id) { return await _repository.GetById(id); }

        public async Task<User> Update(int id, User user) { throw new NotImplementedException(); }
        
        public (bool verified, bool needsUpgrade) CheckPassword(string password, string loginDtoPassword)
        {
            return _encryptor.Check(password, loginDtoPassword);
        }

        public string EncryptPassword(string loginDtoPassword) { return _encryptor.EncryptPassword(loginDtoPassword); }
        
        public AppSettings GetAppSettings() { return _appSettings; }
    }
}