namespace Domain.Entities.JoinEntities;

public class PositionSkill
{
    private PositionSkill()
    {
        
    }
    private PositionSkill
        (
            Guid positionId, Guid skillId,
            Position position, Skill skill
        )
    {
        PositionId = positionId;
        SkillId = skillId;
        Position = position;
        Skill = skill;
    }

    public Guid PositionId { get; set; } = Guid.Empty;
    public Guid SkillId { get; set; } = Guid.Empty;

    // Navigation Properties
    public virtual Position Position { get; set; } = default!;  
    public virtual Skill Skill { get; set; } = default!;

    public static PositionSkill Create
        (
            Guid positionId, Guid skillId,
            Position position, Skill skill
        )
        => new PositionSkill
        (
            positionId, skillId, position, skill
        );
}
