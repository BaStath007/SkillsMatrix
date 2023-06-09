using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.EmployeeDTOs;
using Application.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly ISkillsMatrixDbContext _context;

    public EmployeeRepository(SkillsMatrixDbContext context)
    {
        _context = context;
    }

    public async Task<EmployeeGetDTO?> GetById(Guid id, CancellationToken cancelationToken)
    {
        var employee = await _context.Employees.AsNoTracking().Include(e => e.Role)
            .Include(e => e.Team).Include(e => e.EmployeeSkills)
            .FirstOrDefaultAsync(e => e.Id == id, cancelationToken);
        return EmployeeExtensions.GetEmployeeToApplication(employee);
    }

    public async Task<List<EmployeeGetDTO>> GetAll(CancellationToken cancellationToken)
    {
        var employees = await _context.Employees.ToListAsync(cancellationToken);
        return EmployeeExtensions.GetAllEmployeesToApplication(employees);
    }

    public void Add(EmployeeCreateDTO entity)
    {
        throw new NotImplementedException();
    }

    public void Update(EmployeeUpdateDTO entity)
    {
        throw new NotImplementedException();
    }

    public void SoftDelete(EmployeeDeleteDTO entity)
    {
        throw new NotImplementedException();
    }
}
