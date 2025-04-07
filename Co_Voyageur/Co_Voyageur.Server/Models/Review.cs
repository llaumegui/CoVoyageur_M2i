namespace Co_Voyageur.Server.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string? Comments { get; set; }
        public int Rate {  get; set; }
        public User? User { get; set; }

    }
}
