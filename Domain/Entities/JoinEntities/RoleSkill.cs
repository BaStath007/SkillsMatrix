using Domain.Shared;

namespace Domain.Entities.JoinEntities;

public class RoleSkill
{
    public RoleSkill()
    {
        
    }
    private RoleSkill(Guid roleId, Guid skillId, Option<Role> role, Option<Skill> skill)
    {
        RoleId = roleId;
        SkillId = skillId;
        Role = role;
        Skill = skill;
    }

    public Guid RoleId { get; set; } = Guid.Empty;
    public Guid SkillId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Option<Role> Role { get; set; }
    public virtual Option<Skill> Skill { get; set; }

    public static RoleSkill Create(Guid roleId, Guid skillId, Option<Role> role,
        Option<Skill> skill)
            => new(roleId, skillId, role, skill);
}
