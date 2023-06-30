using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EmployeeSkillDTOs;

public class EmployeeSkillAddOrUpdateDTO
{
    private const int MinMastery = 1;
    private const int MaxMastery = 5;

    public EmployeeSkillAddOrUpdateDTO
        (
            Guid skillId, string accreditedBy,
            int mastery, string updatedMasteryBy
        )
    {
        SkillId = skillId;
        AccreditedBy = accreditedBy;
        Mastery = mastery;
        UpdatedMasteryBy = updatedMasteryBy;
    }

    public Guid SkillId { get; private init; } 
    public string AccreditedBy { get; private init; } = string.Empty;
    [Range(MinMastery, MaxMastery)]
    public int Mastery { get; private init; }
    public string UpdatedMasteryBy { get; private init; } = string.Empty;
}
