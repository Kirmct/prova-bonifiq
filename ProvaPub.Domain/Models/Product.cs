namespace ProvaPub.Domain.Models
{
    public class Product : Entity
    {
        public Product(string name)
        {
            Name = name;
        }

        public Product(string name, int id) : base(id)
        {
            Name = name;
        }

        public string Name { get; set; } = null!;
    }
}
