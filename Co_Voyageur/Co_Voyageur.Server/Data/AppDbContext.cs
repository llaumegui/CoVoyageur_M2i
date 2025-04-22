using Co_Voyageur.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Co_Voyageur.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public AppDbContext() { }
        
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Step> Steps { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(InitialData.users);
            modelBuilder.Entity<Trip>()
           .HasOne(t => t.Driver)
           .WithMany()
           .HasForeignKey(t => t.DriverId)
           .OnDelete(DeleteBehavior.Restrict);
            /*
            modelBuilder.Entity<Car>().HasData(InitialData.cars);
            modelBuilder.Entity<Review>().HasData(InitialData.reviews);
            modelBuilder.Entity<Step>().HasData(InitialData.steps);
            modelBuilder.Entity<Trip>().HasData(InitialData.trips);*/
        }
    }
}