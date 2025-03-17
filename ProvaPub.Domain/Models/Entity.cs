namespace ProvaPub.Domain.Models;
public abstract class Entity
{
    protected Entity()
    {}

    protected Entity(int id)
    {
        Id = id;
    }
    
    public int Id { get; protected set; }
}
