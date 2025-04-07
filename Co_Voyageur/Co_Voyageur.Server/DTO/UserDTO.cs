using System.ComponentModel.DataAnnotations;
using Co_Voyageur.Server.Validators;
namespace Co_Voyageur.Server.DTO;

public class UserDTO
{
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Firstname is required.")]
    [StringLength(20, ErrorMessage = "The name must be between 2 and 20 characters.")]
    [RegularExpression(@"^[A-Z][A-Za-z\- ]*$", ErrorMessage = "The name must start with a capital letter and must end with a capital letter.")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Lastname is required.")]
    [StringLength(20, ErrorMessage = "The name must be between 2 and 20 characters.")]
    [RegularExpression(@"^[A-Z][A-Za-z\- ]*$", ErrorMessage = "The name must start with a capital letter and must end with a capital letter.")]
    public string? LastName { get; set; }
    
    [Url]
    public string? Picture { get; set; }
    
    [Required]
    [PasswordValidator]
    public string? Password { get; set; }
    
    [Required]
    [EmailAddress]
    public string? Email { get; set; }
    
    [Required]
    [Phone]
    public string? Phone { get; set; }
}