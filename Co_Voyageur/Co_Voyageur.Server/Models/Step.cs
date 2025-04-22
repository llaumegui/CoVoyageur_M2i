using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Co_Voyageur.Server.Models
{
    public class Step
    {
        public int Id { get; set; }
        [Required]
        public string Departure { get; set; }
        [Required]
        public string Arrival { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int TripId { get; set; }
        public Trip Trip { get; set; }


    }
}
