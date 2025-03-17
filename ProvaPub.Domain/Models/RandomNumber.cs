namespace ProvaPub.Domain.Models
{
    public class RandomNumber : Entity
    {
        public RandomNumber(int number)
        {
            Number = number;
        }

        public RandomNumber(int number, int id) : base(id) 
        {
            Number = number;
        }

        public int Number { get; private set; }
    }
}
