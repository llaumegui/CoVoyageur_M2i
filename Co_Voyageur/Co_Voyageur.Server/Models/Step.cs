using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.Models
{
    public class Step
    {
        public int Id { get; set; }
        [Required]
        public string? Position { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public Trip? Trip { get; set; }
    }
}
