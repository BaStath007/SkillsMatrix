namespace Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; protected init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; protected init; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; protected set; } = null;
    public DateTime? DeletedAt { get; protected set; } = null;
    public string CreatedBy { get; private init; }
    public string? UpdatedBy { get; protected set; } = string.Empty;
    public string? DeletedBy { get; protected set; } = string.Empty;
    public bool IsActive { get; protected set; } = false;
    public bool IsDeleted { get; protected set; } = false;

    protected Entity(string createdBy)
    {
        CreatedBy = createdBy;
    }

    public static bool operator ==(Entity? first, Entity? second)
    {
        return first is not null && second is not null && first.Equals(second);
    }

    public static bool operator !=(Entity? first, Entity? second)
    {
        return !(first == second);
    }

    public bool Equals(Entity? other)
    {
        if (other == null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }
        return other.Id == Id && other.CreatedAt == CreatedAt && other.UpdatedAt == UpdatedAt
        && other.DeletedAt == DeletedAt && other.CreatedBy == CreatedBy && other.UpdatedBy == UpdatedBy
        && other.DeletedBy == DeletedBy && other.IsActive == IsActive && other.IsDeleted == IsDeleted; 
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.GetType() != GetType()) 
        {
            return false;
        } 

        if (obj is not Entity entity)
        {
            return false;
        }

        return entity.Id == Id && entity.CreatedAt == CreatedAt && entity.UpdatedAt == UpdatedAt
            && entity.DeletedAt == DeletedAt && entity.CreatedBy == CreatedBy && entity.UpdatedBy == UpdatedBy
            && entity.DeletedBy == DeletedBy && entity.IsActive == IsActive && entity.IsDeleted == IsDeleted;
    }

    public override int GetHashCode()
    {
        HashCode hash = new();
        hash.Add(Id);
        hash.Add(CreatedAt);
        hash.Add(CreatedBy);
        hash.Add(UpdatedAt);
        hash.Add(UpdatedBy);
        hash.Add(DeletedAt);
        hash.Add(DeletedBy);
        hash.Add(IsActive);
        hash.Add(IsDeleted);
        return hash.ToHashCode();
    }
}
