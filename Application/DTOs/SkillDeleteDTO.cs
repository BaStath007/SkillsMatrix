namespace Application.DTOs;

public sealed class SkillDeleteDTO
{
    public Guid Id { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
    public bool? IsActive { get; set; }
    public bool? IsDeleted{ get; set; }

    public SkillDeleteDTO(Guid id, string? deletedBy)
    {
        Id = id;
        DeletedAt = DateTime.UtcNow;
        DeletedBy = deletedBy;
        IsActive = false;
        IsDeleted = true;
    }
}

