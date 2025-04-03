using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.Models
{
    public class Trip
    {
        public int Id { get; set; }
        [Required]
        public User? User { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public Step[]? Steps { get; set; }
        public User[]? Users { get; set; }
    }
}
