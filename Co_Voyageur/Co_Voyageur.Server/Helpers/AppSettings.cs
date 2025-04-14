namespace Co_Voyageur.Server.Helpers;

public class AppSettings
{
    public required string SecretKey { get; set; }
    public required int TokenExpirationDays { get; set; }
}