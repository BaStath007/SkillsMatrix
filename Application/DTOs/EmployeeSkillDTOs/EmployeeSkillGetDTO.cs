using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.EmployeeSkillDTOs;

public class EmployeeSkillGetDTO
{
    private const int MinMastery = 1;
    private const int MaxMastery = 5;

    private EmployeeSkillGetDTO
        (
            Guid employeeId, Guid skillId, DateTime accreditedAt,
            string accreditedBy, int mastery, DateTime? updatedMasteryAt,
            string? updatedMasteryBy, Employee employee, Skill skill
        )
    {
        EmployeeId = employeeId;
        SkillId = skillId;
        AccreditedAt = accreditedAt;
        AccreditedBy = accreditedBy;
        Mastery = mastery;
        UpdatedMasteryAt = updatedMasteryAt;
        UpdatedMasteryBy = updatedMasteryBy;
        Employee = employee;
        Skill = skill;
    }

    public Guid EmployeeId { get; set; }
    public Guid SkillId { get; set; }
    public DateTime AccreditedAt { get; set; }
    public string AccreditedBy { get; set; }
    [Range(MinMastery, MaxMastery)]
    public int Mastery { get; set; }
    public DateTime? UpdatedMasteryAt { get; set; }
    public string? UpdatedMasteryBy { get; set; }
    public Employee Employee { get; set; }
    public Skill Skill { get; set; }

    public static EmployeeSkillGetDTO Create
        (
            Guid employeeId, Guid skillId, DateTime accreditedAt,
            string accreditedBy, int mastery, DateTime? updatedMasteryAt,
            string? updatedMasteryBy, Employee employee, Skill skill
        )
        => new(
                employeeId, skillId, accreditedAt,
                accreditedBy, mastery, updatedMasteryAt,
                updatedMasteryBy, employee, skill
            );
}
