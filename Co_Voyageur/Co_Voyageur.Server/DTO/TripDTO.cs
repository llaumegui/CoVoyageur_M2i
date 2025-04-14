using Co_Voyageur.Server.Models;
using System.ComponentModel.DataAnnotations;

namespace Co_Voyageur.Server.DTO
{
    public class TripDTO
    {
        public int Id { get; set; }

        public int DriverId { get; set; }

        public double Price { get; set; }

        public List<Step> Steps { get; set; } = [];
        public List<User> Users { get; set; } = [];
    }
}
