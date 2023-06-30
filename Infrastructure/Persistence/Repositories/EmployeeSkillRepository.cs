using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.EmployeeSkillDTOs;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class EmployeeSkillRepository : IEmployeeSkillRepository
{
    private readonly ISkillsMatrixDbContext _context;

    public EmployeeSkillRepository(SkillsMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<List<EmployeeSkillGetDTO>> GetSkillsByEmployeeId(
        Guid employeeId, CancellationToken cancellationToken)
    {
        var employeeSkills = await _context.EmployeeSkills.AsNoTracking()
            .Where(es => es.EmployeeId == employeeId)
            .Include(es => es.Skill)
            .Include(es => es.Employee)
            .ToListAsync(cancellationToken);
        return EmployeeSkillExtensions.GetEmployeeSkillsToApplication(employeeSkills);
    }

    public void AddEmployeeSkills(Guid employeeId, ICollection<EmployeeSkillCreateDTO> employeeSkillCreateDTOs)
    {
        var employeeSkills = EmployeeSkillExtensions.CreateEmployeeSkillsToDomain(employeeId, employeeSkillCreateDTOs);
        foreach (var employeeSkill in employeeSkills)
        {
            _context.EmployeeSkills.Add(employeeSkill);
        }
    }

    public void UpdateEmployeeSkills(Guid employeeId, ICollection<EmployeeSkillGetDTO> employeeSkillGetDTOs, ICollection<EmployeeSkillAddOrUpdateDTO> employeeSkillAddOrUpdateDTOs)
    {
        var employeeSkills = EmployeeSkillExtensions.UpdateEmployeeSkillsToDomain(
            employeeId, employeeSkillGetDTOs, employeeSkillAddOrUpdateDTOs);
        foreach (var employeeSkill in employeeSkills)
        {
            if (employeeSkill.UpdatedMasteryBy == string.Empty)
            {
                _context.EmployeeSkills.Add(employeeSkill);
            }
            else
            {
                _context.EmployeeSkills.Update(employeeSkill);
            }
        }
    }
}
