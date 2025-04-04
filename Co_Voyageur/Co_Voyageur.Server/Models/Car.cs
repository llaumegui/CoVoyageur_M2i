using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [ForeignKey("UserId")]
        public User? User { get; set; }

        public int UserId {  get; set; }

    }
}
