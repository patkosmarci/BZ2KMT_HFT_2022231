using BZ2KMT_HFT_2021222.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace BZ2KMT_HFT_2021222.Repository
{   
    public class CarRentDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<Person> Persons { get; set; }

        public CarRentDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                //string conn = @"Data Source = (LocalDB)\MSSQLLocalDB; " +
                //    @"AttachDbFilename =|DataDirectory|\CarRentDb.mdf; Integrated Security = True; MultipleActiveResultSets = True";

                builder
                    .UseInMemoryDatabase("database")
                    .UseLazyLoadingProxies();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasOne(car => car.Brand)
                .WithMany(Brand => Brand.Cars)
                .HasForeignKey(car => car.BrandId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Person>()
                .HasMany(x => x.Cars)
                .WithMany(x => x.Persons)
                .UsingEntity<Loan>(
                    x => x.HasOne(x => x.Car)
                        .WithMany().HasForeignKey(x => x.CarId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.Person)
                        .WithMany().HasForeignKey(x => x.PersonId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Loan>()
                .HasOne(x => x.Car)
                .WithMany(car => car.Loans)
                .HasForeignKey(x => x.CarId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Loan>()
                .HasOne(x => x.Person)
                .WithMany(person => person.Loans)
                .HasForeignKey(x => x.PersonId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Car>().HasData(new Car[]
            {
                new Car("1#Swift#Sport#Petrol#1989#2"),
                new Car("2#Bora#Sedanl#Petro#2003#1"),
                new Car("3#Atreon#Sedanl#Diesel#2017#1"),
                new Car("4#Astra#Combi#Petrol#1997#3"),
                new Car("5#Camaro#Sport#Petrol#2004#5"),
                new Car("6#Cinquecento#Combi#Petrol#1989#4"),
                new Car("7#200#Combi#Diesel#2006#8"),
                new Car("8#A#Combi#Diesel#2001#9"),
                new Car("9#Clio#Combi#Petrol#2000#10"),
                new Car("10#Mondeo#Combi#Diesel#2006#6"),
                new Car("11#Orion#Sedan#Petrol#1996#6"),
                new Car("12#X#Combi#Petrol#2017#7")
            });

            modelBuilder.Entity<Brand>().HasData(new Brand[]
            {
                new Brand("1#Volkswagen"),
                new Brand("2#Suzuki"),
                new Brand("3#Opel"),
                new Brand("4#Fiat"),
                new Brand("5#Chevrolet"),
                new Brand("6#Ford"),
                new Brand("7#Hyundai"),
                new Brand("8#Peugeot"),
                new Brand("9#Mercedes-Benz"),
                new Brand("10#Renault")
            });

            modelBuilder.Entity<Loan>().HasData(new Loan[]
            {
                new Loan("1#2021-12-21#3#1#128"),
                new Loan("2#2021-10-30#2#2#212"),
                new Loan("3#2019-05-03#5#3#50"),
                new Loan("4#2000-12-12#10#4#98")
            });

            modelBuilder.Entity<Person>().HasData(new Person[]
            {
                new Person("1#Walter#White#Albaquerque 303699 Pizza Street#+35234124123567#12341234#51234151"),
                new Person("2#Horváth#White#Albaquerque 303699 Pizza Street#+35234124123567#12341234#51234151"),
                new Person("3#Benjámin#White#Albaquerque 303699 Pizza Street#+35234124123567#12341234#51234151"),
                new Person("4#Valami#White#Albaquerque 303699 Pizza Street#+35234124123567#12341234#51234151")
            });
        }
    }
}
