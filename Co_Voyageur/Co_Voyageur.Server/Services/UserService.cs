using System.Security.Claims;
using AutoMapper;
using Co_Voyageur.Server.DTO.Authentification;
using Co_Voyageur.Server.Helpers;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Repositories;
using Co_Voyageur.Server.Services.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc;
using Constants = Co_Voyageur.Server.Helpers.Constants;

namespace Co_Voyageur.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User, int> _userRepository;
        private readonly AppSettings _appSettings;
        private readonly Encryptor _encryptor;
        private readonly IMapper _mapper;
        

        public UserService(IUserRepository<User, int> userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
            _encryptor = new();
        }

        public async Task<User> Create(User user) { return await _userRepository.Add(user); }

        public async Task Delete(int id) { await _userRepository.Delete(id); }

        public async Task<IEnumerable<User>> GetAll() { return await _userRepository.GetAll(); }

        public async Task<User?> GetByEmail(string email)
        {
            return await _userRepository.GetByPredicate(u => u.Email == email);
        }

        public async Task<User?> GetById(int id) { return await _userRepository.GetById(id); }

        public async Task<User> Update(int id, User user) { throw new NotImplementedException(); }
        
        public (bool verified, bool needsUpgrade) CheckPassword(string password, string loginDtoPassword)
        {
            return _encryptor.Check(password, loginDtoPassword);
        }

        public string EncryptPassword(string loginDtoPassword) { return _encryptor.EncryptPassword(loginDtoPassword); }
        
        public AppSettings GetAppSettings() { return _appSettings; }
    }
}