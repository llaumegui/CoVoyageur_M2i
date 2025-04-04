using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Data
{
    public class InitialData
    {
        public static readonly List<User> users = new List<User>()
        {
            new User{Id = 1, FirstName="Mister", LastName="Admin", Email="Admin.Root@gmail.com", Password="root",Phone="0102030405", IsAdmin=true},
            new User{Id = 2, FirstName="John", LastName="Doe", Email="John.Doe@gmail.com", Password="test",Phone="0504030201", IsAdmin=false},
        };

        public static readonly List<Car> cars = new List<Car>()
        {
            new Car{Id = 1, Model="Citroen Saxo", Color="Blanche", PassengerSize=5, Plate="E53C-BX23" },
            new Car{Id = 2, Model="Fiat Panda", Color="Blanche", PassengerSize=2, Plate="VC34-PD42" },
        };

    }
}
