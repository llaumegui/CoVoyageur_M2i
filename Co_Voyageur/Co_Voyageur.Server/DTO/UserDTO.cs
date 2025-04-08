using System.ComponentModel.DataAnnotations;
using Co_Voyageur.Server.Validators;
namespace Co_Voyageur.Server.DTO;

public class UserDTO
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Picture { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public bool IsAdmin { get; set; }
    public bool IsVerified { get; set; }
}