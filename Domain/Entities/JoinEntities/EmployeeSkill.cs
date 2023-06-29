using System.ComponentModel.DataAnnotations;

namespace Domain.Entities.JoinEntities;

public class EmployeeSkill
{
    private const int MinMastery = 1;
    private const int MaxMastery = 5;

    private EmployeeSkill()
    {
        
    }

    // This is called from static method Create
    private EmployeeSkill
        (
            Guid employeeId, Guid skillId, string accreditedBy, int mastery
        )
    {
        EmployeeId = employeeId;
        SkillId = skillId;
        AccreditedAt = DateTime.UtcNow;
        AccreditedBy = accreditedBy;
        Mastery = mastery;
    }

    // This is called from static method Update
    private EmployeeSkill
        (
            Guid employeeId, Guid skillId, string accreditedBy,
            int mastery, string updatedMasteryBy, DateTime updatedMasteryAt
        )
    {
        EmployeeId = employeeId;
        SkillId = skillId;
        AccreditedAt = DateTime.UtcNow;
        AccreditedBy = accreditedBy;
        Mastery = mastery;
        UpdatedMasteryBy = updatedMasteryBy;
        UpdatedMasteryAt = updatedMasteryAt;
    }

    public Guid EmployeeId { get; private init; } = Guid.Empty;
    public Guid SkillId { get; private init; } = Guid.Empty;
    public DateTime AccreditedAt { get; private set; }
    public string AccreditedBy { get; private set; } = string.Empty;
    [Range(MinMastery, MaxMastery)]
    public int Mastery { get; private set; }
    public string? UpdatedMasteryBy { get; private set; }
    public DateTime? UpdatedMasteryAt { get; private set; }

    // Navigation Properties
    public virtual Employee Employee { get; set; } = default!;
    public virtual Skill Skill { get; set; } = default!;   

    public static EmployeeSkill Create
        (
            Guid employeeId, Guid skillId, string accreditedBy, int mastery
        ) 
        => new EmployeeSkill
        (
            employeeId, skillId, accreditedBy, mastery
        );

    public static EmployeeSkill Update
        (
            Guid employeeId, Guid skillId, string accreditedBy,
            int mastery, string updatedMasteryBy, DateTime updatedMasteryAt
        )
        => new EmployeeSkill
        (
            employeeId, skillId, accreditedBy,
            mastery, updatedMasteryBy, updatedMasteryAt
        );
}
