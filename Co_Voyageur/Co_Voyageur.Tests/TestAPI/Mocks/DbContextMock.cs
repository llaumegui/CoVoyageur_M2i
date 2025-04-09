using System.Linq.Expressions;
using Co_Voyageur.Server.Data;
using Co_Voyageur.Server.Models;
using Moq;
using Moq.EntityFrameworkCore;

namespace Co_Voyageur.Tests.TestAPI.Mocks;

public class DbContextMock
{
    public static AppDbContext GetMock(List<User> entities)
    {
        var mock = new Mock<AppDbContext>();
        mock.Setup(x => x.Users).ReturnsDbSet(entities);
        return mock.Object;
    }
}