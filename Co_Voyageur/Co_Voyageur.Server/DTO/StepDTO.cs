using Co_Voyageur.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.DTO
{
    public class StepDTO
    {
        public int Id { get; set; }
        public string? Position { get; set; }
        public DateTime Date { get; set; }
        public int TripId { get; set; }


    }
}
