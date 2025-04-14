using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        [Required]
        public int Rate {  get; set; }
        public User? User { get; set; }

    }
}
