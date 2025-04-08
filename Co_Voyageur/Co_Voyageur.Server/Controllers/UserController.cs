using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Co_Voyageur.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET /clients
        [HttpGet]
        [SwaggerOperation(Summary = "Obtenir la liste des users")]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var clients = await _userService.GetAll();
            return Ok(clients);
        }
    }
}
