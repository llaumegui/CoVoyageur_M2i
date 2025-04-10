using Co_Voyageur.Server.Models;
using Co_Voyageur.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Co_Voyageur.Server.Controllers;

[ApiController]
[Route("api/review")]
public class ReviewController(ReviewService service) : ControllerBase
{
    [HttpGet("reviews")]
    [SwaggerOperation(Summary = "Obtenir la liste des objets")]
    [ProducesResponseType(typeof(IEnumerable<Review>), StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var items = await service.GetAll();
        return Ok(items);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Obtenir un objet par ID")]
    [ProducesResponseType(typeof(Review), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(int id)
    {
        var item = await service.GetById(id);
        return item != null ? Ok(item) : NotFound($"objet avec l'id {id} non trouvé.");
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Créer un nouvel objet")]
    [ProducesResponseType(typeof(Review), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] Review item)
    {
        try
        {
            var newItem = await service.Create(item);
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
    [ProducesResponseType(typeof(Review), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update(int id, [FromBody] Review user)
    {
        try
        {
            var updatedItem = await service.Update(id, user);
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