using Co_Voyageur.Server.Models;

namespace Co_Voyageur.Server.Data
{
    public class InitialData
    {
        public static readonly List<User> users = new()
        {
            new User
            {
                Id = 1, FirstName = "Mister", LastName = "Admin", Email = "Admin.Root@gmail.com", Password = "root",
                Phone = "0102030405", IsAdmin = true
            },
            new User
            {
                Id = 2, FirstName = "John", LastName = "Doe", Email = "John.Doe@gmail.com", Password = "test",
                Phone = "0504030201", IsAdmin = false
            },
        };

        /*public static readonly List<Car> cars = new()
        {
            new Car { Id = 1, Model = "Chevrolet Aveo", PassengerSize = 3, Plate = "pipipi", User = users[0] },
            new Car { Id = 1, Model = "Renaud Sonic", PassengerSize = 5, Plate = "cacaca", User = users[1] }
        };

        public static readonly List<Review> reviews = new()
        {
            new Review { Id = 1, Comment = "nul", Rate = 1, User = users[0] },
            new Review { Id = 2, Rate = 10, User = users[0] }
        };

        public static readonly List<Trip> trips = new()
        {
            new Trip { Id = 1, DriverId = users[0].Id, Price = 1000, Steps = steps }
        };

        public static readonly List<Step> steps = new()
        {
            new Step { Position = "pipouVille", Date = DateTime.Now, Trip = trips[0] },
            new Step { Position = "zigoudascq", Date = DateTime.Now, Trip = trips[0] },
        };*/
    }
}