using Co_Voyageur.Server.Models;
namespace Co_Voyageur.Server.DTO.Authentification;

public class LoginResponseDTO
{
    public bool IsSuccessful { get; set; }
    public string? ErrorMessage { get; set; }
    public User? User { get; set; }
}