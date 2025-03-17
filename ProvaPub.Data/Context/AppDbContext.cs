using Microsoft.EntityFrameworkCore;
using ProvaPub.Domain.Models;

namespace ProvaPub.Infra.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().HasData(SeedData.GetCustomers());
            modelBuilder.Entity<Product>().HasData(SeedData.GetProducts());
            modelBuilder.Entity<RandomNumber>().HasIndex(s => s.Number).IsUnique();
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<RandomNumber> Numbers { get; set; }
    }

}