using Co_Voyageur.Server.DTO;
using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Services;
using Co_Voyageur.Server.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Co_Voyageur.Server.Controllers;

[ApiController]
[Route("api/trip")]
public class TripController : ControllerBase
{
    private readonly TripService _tripService;
    private readonly UserService _userService;

    public TripController(TripService tripService, UserService userService)
    {
        _tripService = tripService;
        _userService = userService;
    }

    [HttpGet("trips")]
    [SwaggerOperation(Summary = "Obtenir la liste des objets")]
    [ProducesResponseType(typeof(IEnumerable<Trip>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var items = await _tripService.GetAll();
        return Ok(items);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtenir un objet par ID")]
    [ProducesResponseType(typeof(Review), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await _tripService.GetById(id);
        return item != null ? Ok(item) : NotFound($"objet avec l'id {id} non trouvé.");
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Créer un nouvel objet")]
    [ProducesResponseType(typeof(Trip), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] TripDTO tripDTO)
    {
        try
        {
            var driver = await _userService.GetById(tripDTO.DriverId);
            if (driver == null)
            {
                return NotFound($"driver with {tripDTO.DriverId} not found");
            }
            var steps = tripDTO.Steps.Select(s => new Step
            {
                Departure = s.Departure,
                Arrival = s.Arrival,
                Date = s.Date
            }).ToList();

            var newTrip = new Trip
            {
                Driver = driver,
                Price = tripDTO.Price,
                Steps = steps
            };
            var newItem = await _tripService.Create(newTrip);
            return CreatedAtAction(nameof(GetById),
                new { id = newItem.Id },
                newItem);
        }
        catch (Exception ex)
        {
            return BadRequest($"Erreur lors de la création de l'objet : {ex.Message}");
        }
        //try
        //{
        //    var newItem = await _tripService.Create(item);
        //    return CreatedAtAction(nameof(GetById),
        //        new { id = newItem.Id },
        //        newItem);
        //}
        //catch (Exception ex)
        //{
        //    return BadRequest($"Erreur lors de la création de l'objet : {ex.Message}");
        //}
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Mettre à jour un objet",
        Description = "Met à jour les informations d'un objet existant.")]
    [ProducesResponseType(typeof(Trip), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] Trip user)
    {
        try
        {
            var updatedItem = await _tripService.Update(id, user);
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
            await _tripService.Delete(id);
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