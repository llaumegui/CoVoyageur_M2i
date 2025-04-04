using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.Models
{
    public class Trip
    {
        public int Id { get; set; }
        [Required]
        public User? UserFrom { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public List<Step>? Steps { get; set; }
        public List<User>? Users { get; set; }
    }
}
