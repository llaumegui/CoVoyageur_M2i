using Co_Voyageur.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public int PassengerSize { get; set; }
        public string? Color { get; set; }
        public string? Plate { get; set; }

        public int UserId { get; set; }
    }

}
