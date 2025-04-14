using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Helpers;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Repositories;
using Co_Voyageur.Server.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Co_Voyageur.Tests.TestAPI.Mocks;

public class IUserServiceMock
{
    public static UserService GetMock()
    {
        List<User> lstUsers = GenerateUsers();
        AppDbContext dbContextMock = DbContextMock.GetMock(lstUsers);
        UserRepository userRepository = new UserRepository(dbContextMock);
        
        IOptions<AppSettings> appSettings = new OptionsWrapper<AppSettings>(new AppSettings
        {
            SecretKey = "This is my secret key for My Service Mocks, i want to die hahaha",
            TokenExpirationDays = 1
        });
        
        return new UserService(userRepository, appSettings);
    }

    private static List<User> GenerateUsers()
    {
        return new List<User>()
        {
            new User
            {
                Id = 1,
                Email = "test@test.com",
                Password = "test",
                FirstName = "TestUser",
                LastName = "TestUser",
                Phone = "0303030303"
            },
            new User
            {
                Id = 2,
                Email = "test@test.com",
                Password = "test",
                FirstName = "TestAdmin",
                LastName = "TestAdmin",
                Phone = "0303030303",
                IsAdmin = true,
            },
        };
    }
}