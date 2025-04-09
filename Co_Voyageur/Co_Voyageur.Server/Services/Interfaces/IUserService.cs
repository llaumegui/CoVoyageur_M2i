using Co_Voyageur.Server.DTO.Authentification;
using Co_Voyageur.Server.Helpers;
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
        (bool verified, bool needsUpgrade) CheckPassword(string password, string loginDtoPassword);
        string EncryptPassword(string loginDtoPassword);
        AppSettings GetAppSettings();
    }
}
