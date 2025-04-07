using Co_Voyageur.Server.Models;
using Microsoft.EntityFrameworkCore;


namespace Co_Voyageur.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Car> Cars  { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Step> Steps { get; set; }
        public DbSet<Trip> Trips { get; set; }

        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(InitialData.users);
            //modelBuilder.Entity<Car>().HasData(InitialData.cars);

            //modelBuilder.Entity<User>()
            //.HasMany(c => c.TripsHistory)
            //.WithOne(r => r.UserFrom)
            //.HasPrincipalKey(c => c.Id);

            //modelBuilder.Entity<Car>()
            // .HasOne(c => c.User)
            // .WithOne(c => c.Car);

            //modelBuilder.Entity<Step>()
            // .HasOne(c => c.Trip)
            // .WithMany(r => r.Steps)
            // .HasPrincipalKey(c=>c.Id);


            //modelBuilder.Entity<Review>()
            // .HasOne(c => c.UserFrom)
            // .WithMany(r => r.Reviews)
            // .HasPrincipalKey(c => c.Id);
        }
    }
}
