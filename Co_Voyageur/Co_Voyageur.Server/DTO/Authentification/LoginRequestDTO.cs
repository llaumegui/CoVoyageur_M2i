using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.DTO.Authentification;

public class LoginRequestDTO
{
    [EmailAddress]
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}