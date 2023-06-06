namespace Domain.Entities.JoinEntities;

public class RoleSkill
{
    public RoleSkill()
    {
        
    }
    private RoleSkill(Guid roleId, Guid skillId, Role role, Skill skill)
    {
        RoleId = roleId;
        SkillId = skillId;
        Role = role;
        Skill = skill;
    }

    public Guid RoleId { get; set; } = Guid.Empty;
    public Guid SkillId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Role Role { get; set; }
    public virtual Skill Skill { get; set; }

    public static RoleSkill Create(Guid roleId, Guid skillId, Role role,
        Skill skill)
            => new(roleId, skillId, role, skill);
}
