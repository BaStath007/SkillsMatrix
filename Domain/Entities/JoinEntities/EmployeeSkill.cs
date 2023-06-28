namespace Domain.Entities.JoinEntities;

public class EmployeeSkill
{
    private EmployeeSkill()
    {
        
    }
    private EmployeeSkill
        (
            Guid employeeId, Guid skillId
        )
    {
        EmployeeId = employeeId;
        SkillId = skillId;
    }
    public Guid EmployeeId { get; set; } = Guid.Empty;
    public Guid SkillId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Employee Employee { get; set; } = default!;
    public virtual Skill Skill { get; set; } = default!;   

    public static EmployeeSkill Create
        (
            Guid employeeId, Guid skillId
        ) 
        => new EmployeeSkill
        (
            employeeId, skillId
        );
}
