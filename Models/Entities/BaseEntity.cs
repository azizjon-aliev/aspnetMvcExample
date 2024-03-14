namespace BlogAPI.Models.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }

    // public BaseEntity()
    // {
    //     Id = Guid.NewGuid();
    // }

    public override string ToString()
    {
        return $"Id:{ Id} ({GetType().Name})";
    }
}