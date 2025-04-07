using AutoMapper;
using Co_Voyageur.Server.DTO;
using Co_Voyageur.Server.DTO.Authentification;
using Co_Voyageur.Server.Helpers;
using Co_Voyageur.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Co_Voyageur.Server.Controllers;

[Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        // TODO : delete when access to UserService
        private readonly IMapper _mapper;
        private Encryptor _encryptor = new();
        public AuthenticationController(IMapper mapper) { _mapper = mapper; }
        
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
        public ActionResult<IEnumerable<UserDTO>> GetUsers()
        {
            return Ok(_users);
        }

        // TODO : make it async for DB
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<RegisterResponseDTO> Register([FromBody] RegisterRequestDTO registerDto)
        {
            if ( _users.FirstOrDefault(u => u.Email == registerDto.Email) != null)
                return BadRequest(new RegisterResponseDTO 
                    { IsSuccessful = false, ErrorMessage = "Email already exist !" });
            
            // TODO : check if admin role is possible
            
            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                Password = Encryptor.EncryptPassword(registerDto.Password!),
                IsAdmin = registerDto.IsAdmin,
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

            var (verified,needsUpgrade) = _encryptor.Check(userDto.Password!, loginDto.Password!);

            if (!verified)
                return BadRequest(new LoginResponseDTO { IsSuccessful = false, ErrorMessage = "Invalid Authentication !" });
            
            if (needsUpgrade)
            {
                userDto.Password = Encryptor.EncryptPassword(loginDto.Password!);
                _users.FirstOrDefault(u=> u == userDto)!.Password = userDto.Password;
            }
            
            // TODO : Add JWT
            
            User user = _mapper.Map<User>(userDto);
            return Ok(new LoginResponseDTO
            {
                IsSuccessful = true,
                User = user
            });
        }
    }