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
    }
}
