using Application.DTOs.EmployeeDTOs;
using Application.DTOs.EmployeeSkillDTOs;
using Domain.Entities;
using Domain.Entities.JoinEntities;

namespace Application.Mapping;

public static class EmployeeSkillExtensions
{
    public static List<EmployeeSkillGetDTO> GetEmployeeSkillsToApplication(
        List<EmployeeSkill> employeeSkills)
    {
        var employeeSkillDTOs = new List<EmployeeSkillGetDTO>();
        foreach (var employeeSkill in employeeSkills)
        {
            var employeeSkillDTO = EmployeeSkillGetDTO.Create(
            employeeSkill.EmployeeId, employeeSkill.SkillId, employeeSkill.AccreditedAt,
            employeeSkill.AccreditedBy, employeeSkill.Mastery, employeeSkill.UpdatedMasteryAt,
            employeeSkill.UpdatedMasteryBy, employeeSkill.Employee, employeeSkill.Skill);
            employeeSkillDTOs.Add(employeeSkillDTO);
        }
        return employeeSkillDTOs;
    }

    public static ICollection<EmployeeSkill> CreateEmployeeSkillsToDomain(
        Guid employeeId, ICollection<EmployeeSkillCreateDTO> employeeSkillCreateDTOs)
    {
        ICollection<EmployeeSkill> employeeSkills = new List<EmployeeSkill>();
        foreach (var employeeSkillCreateDTO in employeeSkillCreateDTOs)
        {
            employeeSkills.Add(EmployeeSkill.Create(
                employeeId, employeeSkillCreateDTO.SkillId,
                employeeSkillCreateDTO.AccreditedBy, employeeSkillCreateDTO.Mastery));
        }

        return employeeSkills;
    }

    public static ICollection<EmployeeSkill> UpdateEmployeeSkillsToDomain(
        Guid employeeId,
        ICollection<EmployeeSkillGetDTO> employeeSkillGetDTOs,
        ICollection<EmployeeSkillAddOrUpdateDTO> employeeSkillAddOrUpdateDTOs)
    {
        ICollection<EmployeeSkill> employeeSkills = new List<EmployeeSkill>();
        foreach (var employeeSkillAddOrUpdateDTO in employeeSkillAddOrUpdateDTOs)
        {
            var oldEmployeeSkill = employeeSkillGetDTOs
                .Where(es => es.SkillId == employeeSkillAddOrUpdateDTO.SkillId)
                .FirstOrDefault();
            if (oldEmployeeSkill is not null)
            {
                employeeSkills.Add(EmployeeSkill.Update(
                    oldEmployeeSkill.EmployeeId, employeeSkillAddOrUpdateDTO.SkillId, oldEmployeeSkill.AccreditedAt,
                    oldEmployeeSkill.AccreditedBy, employeeSkillAddOrUpdateDTO.Mastery,
                    employeeSkillAddOrUpdateDTO.UpdatedMasteryBy));
            }
            else
            {
                employeeSkills.Add(EmployeeSkill.Create(
                    employeeId, employeeSkillAddOrUpdateDTO.SkillId,
                    employeeSkillAddOrUpdateDTO.AccreditedBy,
                    employeeSkillAddOrUpdateDTO.Mastery));
            }
        }   

        return employeeSkills;
    }
}
