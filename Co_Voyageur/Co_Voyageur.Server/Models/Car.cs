using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Co_Voyageur.Server.Models
{
    public class Car
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("model")]
        [Required]
        public string Model { get; set; }
        
        [Column("passenger_size")]
        [Required]
        public int PassengerSize { get; set; }
        
        [Column("color")]
        public string? Color { get; set; }
        
        [Column("plate")]
        [Required]
        public string Plate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
