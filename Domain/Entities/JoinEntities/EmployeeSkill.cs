using Domain.Shared;

namespace Domain.Entities.JoinEntities;

public class EmployeeSkill
{
    private EmployeeSkill(Guid employeeId, Guid skillId, 
        Option<Employee> employee, Option<Skill> skill)
    {
        EmployeeId = employeeId;
        SkillId = skillId;
        Employee = employee;
        Skill = skill;
    }
    public Guid EmployeeId { get; set; } = Guid.Empty;
    public Guid SkillId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Option<Employee> Employee { get; set; }
    public virtual Option<Skill> Skill { get; set; }

    public static EmployeeSkill Create(Guid employeeId, Guid skillId,
        Option<Employee> employee, Option<Skill> skill) 
            => new(employeeId, skillId, employee, skill);
}
