using Co_Voyageur.Server.DTO;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Services;
using Co_Voyageur.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Co_Voyageur.Server.Controllers;

[ApiController]
[Route("api/car")]
public class CarController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly CarService service;
    public CarController(CarService carService, IUserService userService)
    {
        _userService = userService;
        service = carService;
    }

    [HttpGet("cars")]
        [SwaggerOperation(Summary = "Obtenir la liste des objets")]
        [ProducesResponseType(typeof(IEnumerable<Car>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var items = await service.GetAll();
            return Ok(items);
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtenir un objet par ID")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await service.GetById(id);
            return item != null ? Ok(item) : NotFound($"objet avec l'id {id} non trouvé.");
        }
        
        
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouvel objet")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CarDTO carDTO)
        {
            try
            {
                var user = await _userService.GetById(carDTO.UserId);
            if (user == null) {
                return NotFound($"User with {carDTO.UserId} not found");
            }
            var newCar = new Car
            {
                Model = carDTO.Model,
                PassengerSize = carDTO.PassengerSize,
                Color = carDTO.Color,
                Plate = carDTO.Plate,
                User = user
            };
            var newItem = await service.Create(newCar);
                return CreatedAtAction(nameof(GetById), 
                    new { id = newItem.Id }, 
                    newItem);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la création de l'objet : {ex.Message}");
            }
        }
        
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Mettre à jour un objet",
            Description = "Met à jour les informations d'un objet existant.")]
        [ProducesResponseType(typeof(Car), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] CarDTO carDTO)
        {
            try
            {

                var user = await _userService.GetById(carDTO.UserId);
                if (user == null)
                {
                    return NotFound($"User with {carDTO.UserId} not found");
                }
                var newCar = new Car
                {
                    Model = carDTO.Model,
                    PassengerSize = carDTO.PassengerSize,
                    Color = carDTO.Color,
                    Plate = carDTO.Plate,
                    User = user
                };
                var updatedItem = await service.Update(id, newCar);
                return Ok(updatedItem);
            }
            catch (KeyNotFoundException nex)
            {
                return NotFound(nex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la mise à jour de l'objet : {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Supprimer un objet",
            Description = "Supprime un objet à partir de son identifiant.")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await service.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erreur lors de la suppression de l'objet : {ex.Message}");
            }
        }
}