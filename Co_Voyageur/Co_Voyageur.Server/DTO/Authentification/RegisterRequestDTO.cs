using System.ComponentModel.DataAnnotations;
using Co_Voyageur.Server.Validators;

namespace Co_Voyageur.Server.DTO.Authentification;

public class RegisterRequestDTO
{
    [Required(ErrorMessage = "Firstname is required.")]
    [StringLength(20, ErrorMessage = "The name must be between 2 and 20 characters.")]
    [RegularExpression(@"^[A-Z][A-Za-z\- ]*$", ErrorMessage = "The name must start with a capital letter and must end with a capital letter.")]
    public string? FirstName { get; set; }
    
    [Required(ErrorMessage = "Lastname is required.")]
    [StringLength(20, ErrorMessage = "The name must be between 2 and 20 characters.")]
    [RegularExpression(@"^[A-Z][A-Za-z\- ]*$", ErrorMessage = "The name must start with a capital letter and must end with a capital letter.")]
    public string? LastName { get; set; }
    [Required]
    //[PasswordValidator]
    public string? Password { get; set; }
    [Required]
    [DataType(DataType.EmailAddress)]
    public string? Email { get; set; }
    [Required]
    [DataType(DataType.PhoneNumber)]
    public string? Phone { get; set; }
    
    public bool? IsAdmin { get; set; }
}