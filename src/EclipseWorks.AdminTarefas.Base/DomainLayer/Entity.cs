namespace EclipseWorks.AdminTarefas.Base.DomainLayer;

public abstract class Entity<TId>
{
    public Entity()
    {
    }

    public Entity(TId id)
    {
        Id = id;
        Id2 = Guid.NewGuid();
    }


    public TId Id { get; set; }
    public Guid Id2 { get; set; }
}