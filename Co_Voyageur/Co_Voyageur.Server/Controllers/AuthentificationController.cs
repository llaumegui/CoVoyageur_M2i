using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Co_Voyageur.Server.DTO;
using Co_Voyageur.Server.DTO.Authentification;
using Co_Voyageur.Server.Helpers;
using Co_Voyageur.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Co_Voyageur.Server.Controllers;

[ApiController]
[Route("authentication")]
public class AuthenticationController : ControllerBase
{
    // TODO : delete when access to UserService
    private readonly IMapper _mapper;
    private Encryptor _encryptor = new();
    private readonly AppSettings _appSettings;

    public AuthenticationController(IMapper mapper, IOptions<AppSettings> options)
    {
        _mapper = mapper;
        _appSettings = options.Value;
    }

    // TODO : delete when access to DB, won't be an userDTO in DB
    private List<UserDTO> _users =
    [
        new()
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@gmail.com",
            Password = Encryptor.EncryptPassword("123456"),
            IsAdmin = false,
        },
        new()
        {
            FirstName = "Jane",
            LastName = "Doe",
            Email = "janedoe@gmail.com",
            Password = Encryptor.EncryptPassword("123456"),
            IsAdmin = true,
        }
    ];

    // TODO : change to regular user when access to DB
    [HttpGet("users")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<UserDTO>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public ActionResult<IEnumerable<User>> GetUsers() { return Ok(_mapper.Map<List<User>>(_users)); }

    // TODO : make it async for DB
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<RegisterResponseDTO> Register([FromBody] RegisterRequestDTO registerDto)
    {
        if (_users.FirstOrDefault(u => u.Email == registerDto.Email) != null)
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
            Password = Encryptor.EncryptPassword(registerDto.Password!),
            IsAdmin = registerDto.IsAdmin,
            CreatedAt = DateTime.UtcNow,
            CreatedBy = createdBy
        };

        // TODO Add to DB, check if Save is done else return Bad Request
        
        return Ok(new RegisterResponseDTO { IsSuccessful = true, User = user });
    }

    // TODO : make it async for DB
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public ActionResult<LoginResponseDTO> Login([FromBody] LoginRequestDTO loginDto)
    {
        var userDto = _users.FirstOrDefault(u => u.Email == loginDto.Email);

        if (userDto == null)
            return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

        var (verified, needsUpgrade) = _encryptor.Check(userDto.Password!, loginDto.Password!);

        if (!verified)
            return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });

        if (needsUpgrade)
        {
            userDto.Password = Encryptor.EncryptPassword(loginDto.Password!);
            _users.FirstOrDefault(u => u == userDto)!.Password = userDto.Password;
        }

        User user = _mapper.Map<User>(userDto);

        #region JWT
        string role = user.IsAdmin ? Constants.RoleAdmin : Constants.RoleUser;

        var claims = new List<Claim> // detinée à aller dans la partie Payload du JWT
        {
            new(ClaimTypes.Role, role),
            new(Constants.ClaimUserId, user.Id!.ToString()!),
        };

        var securityKey = _appSettings.SecretKey;

        var signingCredentials = new SigningCredentials(
            new SymmetricSecurityKey(Encoding.ASCII.GetBytes(securityKey)),
            SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(_appSettings.TokenExpirationDays),
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
}