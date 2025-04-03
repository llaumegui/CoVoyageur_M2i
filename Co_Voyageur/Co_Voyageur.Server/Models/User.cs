using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;

namespace Co_Voyageur.Server.Models.Users
{
    public class UserBase
    {
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        [PasswordValidator]
        [JsonIgnore]
        public string? Password { get; set; }
        public string? Picture {  get; set; }
        public string? Phone {  get; set; }
        public Review Review { get; set; }
        public bool? IsAdmin { get; set; }
        public Travel Voyage { get; set; }
        public Travel Log {  get; set; }
        public bool? IsVerified { get; set; }
        public Driver Driver { get; set; }

    }
}
