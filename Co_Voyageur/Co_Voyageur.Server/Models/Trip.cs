using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Co_Voyageur.Server.Models
{
    public class Trip
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        [Required]
        public User Driver { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public List<Step> Steps { get; set; } = [];
        public List<User> Users { get; set; } = [];
    }
}
