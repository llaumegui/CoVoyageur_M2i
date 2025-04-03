using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.Models
{
    public class Car
    {

        public int Id { get; set; }
        [Required]
        public string? Model { get; set; }
        [Required]
        public int PassengerSize { get; set; }
        public string? Color { get; set; }
        [Required]
        public string? Plate { get; set; }
        public User User { get; set; }
    }
}
