using Co_Voyageur.Server.DTO;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Services;
using Co_Voyageur.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Co_Voyageur.Server.Controllers;

[ApiController]
[Route("api/step")]
public class StepController : ControllerBase
{
    private readonly StepService _stepService;
    private readonly TripService _tripService;
    public StepController(StepService stepService, TripService tripService)
    {
        _stepService = stepService;
        _tripService = tripService;
    }
    [HttpGet("steps")]
        [SwaggerOperation(Summary = "Obtenir la liste des objets")]
        [ProducesResponseType(typeof(IEnumerable<Step>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            var items = await _stepService.GetAll();
            return Ok(items);
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Obtenir un objet par ID")]
        [ProducesResponseType(typeof(Step), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _stepService.GetById(id);
            return item != null ? Ok(item) : NotFound($"objet avec l'id {id} non trouvé.");
        }
        
        
        [HttpPost]
        [SwaggerOperation(Summary = "Créer un nouvel objet")]
        [ProducesResponseType(typeof(Step), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] StepDTO stepDTO)
        {
            try
            {
                var trip = await _tripService.GetById(stepDTO.Id);
                var newStep = new Step
                {
                    Departure = stepDTO.Departure,
                    Arrival = stepDTO.Arrival,
                    Date = stepDTO.Date,
                    Trip = trip
                };
                var newItem = await _stepService.Create(newStep);
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
        [ProducesResponseType(typeof(Step), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] StepDTO stepDTO)
        {
            try
            {
                var trip = await _tripService.GetById(stepDTO.Id);
                var newStep = new Step
                {
                    Departure = stepDTO.Departure,
                    Arrival = stepDTO.Arrival,
                    Date = stepDTO.Date,
                    Trip = trip
                };
                var updatedItem = await _stepService.Update(id, newStep);
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
                await _stepService.Delete(id);
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