using Co_Voyageur.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.DTO
{
    public class StepDTO
    {
        public int Id { get; set; }
        public string? Departure { get; set; }
        public string? Arrival { get; set; }
        public DateTime Date { get; set; }


    }
}
