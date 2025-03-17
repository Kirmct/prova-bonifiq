using ProvaPub.Domain.Models;

namespace ProvaPub.Infra.Data.Context
{
    public static class SeedData
    {
        public static Customer[] GetCustomers()
        {
            return new Customer[]
            {
                new Customer ("John Doe", 1),
                new Customer ("Jane Smith", 2),
                new Customer ("Mike Johnson", 3),
            };
        }

        public static Product[] GetProducts()
        {
            return new Product[]
            {
                new Product ("Laptop", 1),
                new Product("Smartphone", 2),
                new Product ("Tablet", 3),
            };
        }
    }
}