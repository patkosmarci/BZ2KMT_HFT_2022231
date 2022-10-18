using BZ2KMT_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BZ2KMT_HFT_2021222.Repository
{   
    public class CarRentDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Loans> Loans { get; set; }

        public CarRentDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn = @"Data Source = (LocalDB)\MSSQLLocalDB; " +
                    @"AttachDbFilename =|DataDirectory|\CarRentDb.mdf; Integrated Security = True";

                builder
                    .UseSqlServer(conn);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(car => car
                .HasOne<Brand>()
                .WithMany()
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new Car("1#Swift#Sport#Petrol#1989#2"),
                new Car("2#Bora#Sedanl#Petro#2003#1"),
                new Car("3#Astra#Combi#Petrol#1997#3")
            });

            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand("1#Volkswagen"),
                new Brand("2#Suzuki"),
                new Brand("3#Opel")
            });

            modelBuilder.Entity<Loans>().HasData(new Loans[]
            {

            });
        }
    }
}
