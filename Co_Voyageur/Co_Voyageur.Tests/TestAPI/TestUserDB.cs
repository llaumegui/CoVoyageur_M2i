using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Services;
using Co_Voyageur.Tests.TestAPI.Mocks;

namespace Co_Voyageur.Tests.TestAPI;

[TestClass]
public class TestUserDB
{
    UserService _userService;

    [TestInitialize]
    public void Setup()
    {
        _userService = IUserServiceMock.GetMock();
    }

    [TestMethod]
    public async Task TestGetAll_ShouldReturnNotNull()
    {
        IEnumerable<User> users = await _userService.GetAll();
        
        Assert.IsNotNull(users);
    }
}