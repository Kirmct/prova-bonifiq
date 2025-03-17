namespace ProvaPub.Domain.Models
{
    public class Customer : Entity
    {
        private readonly List<Order> _orders = new();

        protected Customer() { }

        public Customer(string name)
        {
            Name = name;
        }

        public Customer(string name, int id) : base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

        public void AddOrder(Order order)
        {
            if (order == null) throw new ArgumentNullException(nameof(order));
            _orders.Add(order);
        }
    }
}