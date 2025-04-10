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



        public async Task<IEnumerable<User>> GetAll() { return await _repository.GetAll(); }
        
        public async Task<User?> GetById(int id) { return await _repository.GetById(id); }
        
        public async Task<User?> GetByEmail(string email)
        {
            return await _repository.GetByPredicate(u => u.Email == email);
        }
        
        public async Task<User> Create(User user) { return await _repository.Add(user); }

        public async Task<User> Update(int id, User user)
        {
            var oldUser = await _repository.GetById(id);
            if (oldUser == null)
                return null;
            
        if(oldUser.FirstName != user.FirstName)
            oldUser.FirstName = user.FirstName;
        if(oldUser.LastName != user.LastName)
            oldUser.LastName = user.LastName;
        if(oldUser.Email != user.Email)
            oldUser.Email = user.Email;
        if(oldUser.Password != user.Password)
            oldUser.Password = user.Password;
        if(oldUser.Picture != user.Picture)
            oldUser.Picture = user.Picture;
        if(oldUser.Phone != user.Phone)
            oldUser.Phone = user.Phone;
        if(oldUser.IsAdmin!=user.IsAdmin)
            oldUser.IsAdmin = user.IsAdmin;
        if(oldUser.IsVerified != user.IsVerified)
            oldUser.IsVerified = user.IsVerified;
        if (!oldUser.Reviews.Equals(user.Reviews))
            oldUser.Reviews = user.Reviews;
        if (!oldUser.Trips.Equals(user.Trips))
            oldUser.Trips = user.Trips;
       if(oldUser.CreatedAt != user.CreatedAt)
           oldUser.CreatedAt = user.CreatedAt;
        if(oldUser.CreatedBy != user.CreatedBy)
            oldUser.CreatedBy = user.CreatedBy;

        return await _repository.Update(oldUser);
        }
        
        public async Task Delete(int id) { await _repository.Delete(id); }
        
        public (bool verified, bool needsUpgrade) CheckPassword(string password, string loginDtoPassword)
        {
            return _encryptor.Check(password, loginDtoPassword);
        }

        public string EncryptPassword(string loginDtoPassword) { return _encryptor.EncryptPassword(loginDtoPassword); }
        
        public AppSettings GetAppSettings() { return _appSettings; }
    }
}