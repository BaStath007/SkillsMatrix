﻿using Domain.Shared;

namespace Domain.Primitives;

public abstract class Entity : IEquatable<Entity>
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private init; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = default!;
    public DateTime DeletedAt { get; set; } = default!;
    public Option<string> CreatedBy { get; private init; }
    public Option<string> UpdatedBy { get; set; } = null!;
    public Option<string> DeletedBy { get; set; } = null!;
    public bool IsActive { get; set; } = false;
    public bool IsDeleted { get; set; } = false;

    protected Entity(Option<string> createdBy)
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
        unchecked
        {
            int hash = 3;
            hash = hash * 7 + Id.GetHashCode();
            hash = hash * 3 + CreatedAt.GetHashCode();
            hash = hash * 7 + CreatedBy.GetHashCode();
            hash = hash * 3 + UpdatedAt.GetHashCode();
            hash = hash * 7 + UpdatedBy.GetHashCode();
            hash = hash * 3 + DeletedAt.GetHashCode();
            hash = hash * 7 + DeletedBy.GetHashCode();
            hash = hash * 3 + IsActive.GetHashCode();
            hash = hash * 7 + IsDeleted.GetHashCode();
            return hash;
        }
    }
}
