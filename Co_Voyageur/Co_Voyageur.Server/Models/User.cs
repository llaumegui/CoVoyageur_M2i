using Co_Voyageur.Server.Validators;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Co_Voyageur.Server.Models
{
    public class User
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
        public string? Picture { get; set; }
        [Required]
        public string? Phone { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public bool IsVerified { get; set; }
        public List<Review> Reviews { get; set; } = [];
        public List<Trip> Trips { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int? CreatedBy { get; set; }
    }
}
