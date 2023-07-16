using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.EmployeeDTOs;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public sealed class EmployeeRepository : IEmployeeRepository
{
    private readonly ISkillsMatrixDbContext _context;

    public EmployeeRepository(SkillsMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeGetDTO?> GetById(Guid id, CancellationToken cancelationToken)
    {
        var employee = await _context.Employees.AsNoTracking()
            .Include(e => e.Position)
            .Include(e => e.Team)
            .Include(e => e.Skills)!
            .ThenInclude(e => e.ChildrenSkills)
            .FirstOrDefaultAsync(e => e.Id == id, cancelationToken)!;

        return EmployeeExtensions.GetEmployeeToApplication(employee);
    }

    public async Task<List<EmployeeGetDTO>> GetAll(CancellationToken cancellationToken)
    {
        var employees = await _context.Employees.AsNoTracking()
            .Include(e => e.Position)
            .Include(e => e.Team)
            .Include(e => e.Skills)!
            .ThenInclude(e => e.ChildrenSkills)
            .ToListAsync(cancellationToken);

        return EmployeeExtensions.GetAllEmployeesToApplication(employees);
    }

    public Guid Add(EmployeeCreateDTO employeeDTO)
    {
        var employee = EmployeeExtensions.CreateToDomain(employeeDTO);

        _context.Employees.Add(employee);

        return employee.Id;
    }

    public Guid Update(EmployeeUpdateDTO employeeDTO)
    {
        var employee = EmployeeExtensions.UpdateToDomain(employeeDTO);

        _context.Employees.Update(employee);

        return employee.Id;
    }

    public void SoftDelete(EmployeeDeleteDTO employeeDTO)
    {
        _context.Employees.Update(EmployeeExtensions.DeleteToDomain(employeeDTO));
    }
}
