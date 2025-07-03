using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using MyWeatherJournal.API.Models;


namespace MyWeatherJournal.API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "John Carbaugh", Email = "john.carbaugh@outlook.com" }
            );

            modelBuilder.Entity<City>().HasData(
                new City { Id = 1, Name = "Tulsa", State = "OK", Country = "US" },
                new City { Id = 2, Name = "Gulf Breeze", State = "FL", Country = "US" },
                new City { Id = 3, Name = "Albany", State = "NY", Country = "US" },
                new City { Id = 4, Name = "Sacramento", State = "CA", Country = "US" },
                new City { Id = 5, Name = "Seattle", State = "WA", Country = "US" }
            );

            // A "composite" key - meaning it has no primary key and instead uses a combination of two columns as the key
            modelBuilder.Entity<CustomerFavoriteCity>().HasKey(x => new { x.CustomerId, x.CityId });

            modelBuilder.Entity<CustomerFavoriteCity>().HasData(
                new CustomerFavoriteCity { CustomerId = 1, CityId = 1 },
                new CustomerFavoriteCity { CustomerId = 1, CityId = 2 }
            );
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<City> Cities {  get; set; }
        public DbSet<CustomerFavoriteCity> CustomerFavoriteCity { get; set; }
    }
}

