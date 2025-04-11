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
    [Route("api/user")]
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
            var users = await _userService.GetAll();
            return Ok(users);
        }
        
        [HttpGet("users/{id}")]
        [SwaggerOperation(Summary = "Obtenir un user par ID")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userService.GetById(id);
            return user != null ? Ok(user) : NotFound($"User avec l'id {id} non trouvé.");
        }
        
        [HttpGet("{email}")]
        [SwaggerOperation(Summary = "Obtenir un contact par email")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var user = await _userService.GetByEmail(email);
            return user != null ? Ok(user) : NotFound($"User avec le mail \"{email}\" non trouvé.");
        }
        
        // POST /user
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouveau user")]
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] User user)
        {
            try
            {
                var newUser = await _userService.Create(user);
                return CreatedAtAction(nameof(GetById), 
                    new { id = newUser.Id }, 
                    newUser);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création du user : {ex.Message}");
            }
        }
        
        // PUT /user/{id}
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Mettre à jour un user",
            Description = "Met à jour les informations d'un user existant.")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] User user)
        {
            try
            {
                var updatedUser = await _userService.Update(id, user);
                return Ok(updatedUser);
            }
            catch (KeyNotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la mise à jour du user : {ex.Message}");
            }
        }

        // DELETE /user/{id}
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Supprimer un user",
            Description = "Supprime un user à partir de son identifiant.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _userService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression du user : {ex.Message}");
            }
        }
        
    }
}