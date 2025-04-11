using Co_Voyageur.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public int Rate { get; set; }
        public int UserId { get; set; }

    }
}
