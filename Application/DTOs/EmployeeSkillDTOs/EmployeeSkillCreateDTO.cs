using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EmployeeSkillDTOs;

public class EmployeeSkillCreateDTO
{
    private const int MinMastery = 1;
    private const int MaxMastery = 5;

    public EmployeeSkillCreateDTO
        (
            Guid skillId, string accreditedBy, int mastery
        )
    {
        SkillId = skillId;
        AccreditedBy = accreditedBy;
        Mastery = mastery;
    }

    public Guid SkillId { get; private init; } = Guid.Empty;
    public string AccreditedBy { get; private init; } = string.Empty;
    [Range(MinMastery, MaxMastery)]
    public int Mastery { get; private init; }
}
