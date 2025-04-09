using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Co_Voyageur.Server.DTO;
using Co_Voyageur.Server.DTO.Authentification;
using Co_Voyageur.Server.Helpers;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace Co_Voyageur.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) { _userService = userService; }

        [HttpGet("users")]
        [SwaggerOperation(Summary = "Obtenir la liste des users")]
        [ProducesResponseType(typeof(IEnumerable<User>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var clients = await _userService.GetAll();
            return Ok(clients);
        }

        #region Authentification_and_Create
                
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<RegisterResponseDTO>> Register([FromBody] RegisterRequestDTO registerDto)
        {
            var checkUser = await _userService.GetByEmail(registerDto.Email);
            if (checkUser != null)
                return BadRequest(new RegisterResponseDTO
                    { IsSuccessful = false, ErrorMessage = "Email already exist !" });

            if (registerDto.IsAdmin && User.FindFirstValue(ClaimTypes.Role) != Constants.RoleAdmin)
                return Unauthorized(new RegisterResponseDTO
                    { IsSuccessful = false, ErrorMessage = "You can't create an administrator as a user." });

            int? createdBy = null;
            string? userIdClaim = User.FindFirstValue(Constants.ClaimUserId);
            if (!string.IsNullOrEmpty(userIdClaim) && int.TryParse(userIdClaim, out int userId))
            {
                createdBy = userId;
            }

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                Password = _userService.EncryptPassword(registerDto.Password!),
                IsAdmin = registerDto.IsAdmin,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = createdBy
            };

            try
            {
                var newUser = await _userService.Create(user);
                return Ok(new RegisterResponseDTO { IsSuccessful = true, User = newUser });
            }
            catch
            {
                return BadRequest(new RegisterResponseDTO { IsSuccessful = false, ErrorMessage = "Create failed." });
            }
        }

        [HttpGet("login")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginRequestDTO loginDto)
        {
            var user = await _userService.GetByEmail(loginDto.Email);

            if (user == null)
                return BadRequest(new LoginResponseDTO
                    { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

            var (verified, needsUpgrade) = _userService.CheckPassword(user.Password!, loginDto.Password!);

            if (!verified)
                return BadRequest(new LoginResponseDTO
                    { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

            if (needsUpgrade)
            {
                user.Password = _userService.EncryptPassword(loginDto.Password!);
            }

            #region JWT
            string role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

            var claims = new List<Claim> // detinée à aller dans la partie Payload du JWT
            {
                new(ClaimTypes.Role, role),
                new(Constants.ClaimUserId, user.Id!.ToString()!),
            };

            var appSettings = _userService.GetAppSettings();
            var securityKey = appSettings.SecretKey;

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
                SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(appSettings.TokenExpirationDays),
                signingCredentials: signingCredentials
            );

            string token = new JwtSecurityTokenHandler().WriteToken(jwt);
            #endregion

            return Ok(new LoginResponseDTO
            {
                IsSuccessful = true,
                User = user,
                Token = token
            });
        }
        #endregion
    }
}