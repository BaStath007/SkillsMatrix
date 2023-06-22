using Application.DTOs.EmployeeDTOs;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mapping;

public static class EmployeeExtensions
{
    public static EmployeeGetDTO? GetEmployeeToApplication(Employee? employee)
    {
        if (employee is null) return null;

        return EmployeeGetDTO.Create(
            employee.Id, employee.CreatedAt, employee.UpdatedAt, employee.DeletedAt,
            employee.CreatedBy, employee.UpdatedBy, employee.DeletedBy, employee.IsActive,
            employee.IsDeleted, employee.RoleId, employee.TeamId,
            employee.FirstName, employee.EmployeeMiddleName.Map(x => x).Reduce(MiddleName.Create(string.Empty)!.Data),
            employee.LastName, employee.Email, employee.Age, employee.EmployeeSkills);
    }

    public static List<EmployeeGetDTO> GetAllEmployeesToApplication(List<Employee> employees)
    {
        var employeeDTOs = new List<EmployeeGetDTO>();
        foreach (var employee in employees)
        {
            var employeeDTO = EmployeeGetDTO.Create(
            employee.Id, employee.CreatedAt, employee.UpdatedAt, employee.DeletedAt,
            employee.CreatedBy, employee.UpdatedBy, employee.DeletedBy, employee.IsActive,
            employee.IsDeleted, employee.RoleId, employee.TeamId, employee.FirstName,
            employee.EmployeeMiddleName.Map(x => x).Reduce(MiddleName.Create(string.Empty)!.Data),
            employee.LastName, employee.Email, employee.Age, employee.EmployeeSkills);
            employeeDTOs.Add(employeeDTO);
        }
        return employeeDTOs;
    }

    public static Employee CreateToDomain(EmployeeCreateDTO employeeCreateDTO)
    {
        Employee employee = Employee.Create(employeeCreateDTO.CreatedBy, employeeCreateDTO.IsActive, employeeCreateDTO.RoleId,
            employeeCreateDTO.TeamId, employeeCreateDTO.FirstName, employeeCreateDTO.EmployeeMiddleName,
            employeeCreateDTO.LastName, employeeCreateDTO.Email, employeeCreateDTO.Age,
            employeeCreateDTO.EmployeeSkills);
        return employee;
    }

    public static Employee UpdateToDomain(EmployeeUpdateDTO employeeUpdateDTO)
    {
        return Employee.Update(employeeUpdateDTO.Id, employeeUpdateDTO.CreatedAt, employeeUpdateDTO.UpdatedAt,
            employeeUpdateDTO.DeletedAt, employeeUpdateDTO.CreatedBy, employeeUpdateDTO.UpdatedBy,
            employeeUpdateDTO.DeletedBy, employeeUpdateDTO.IsActive, employeeUpdateDTO.IsDeleted,
            employeeUpdateDTO.RoleId, employeeUpdateDTO.TeamId, employeeUpdateDTO.FirstName,
            employeeUpdateDTO.EmployeeMiddleName, employeeUpdateDTO.LastName, employeeUpdateDTO.Email,
            employeeUpdateDTO.Age, employeeUpdateDTO.EmployeeSkills);
    }

    public static Employee DeleteToDomain(EmployeeDeleteDTO employeeDeleteDTO)
    {
        return Employee.Update(employeeDeleteDTO.Id, employeeDeleteDTO.CreatedAt, employeeDeleteDTO.UpdatedAt,
            employeeDeleteDTO.DeletedAt, employeeDeleteDTO.CreatedBy, employeeDeleteDTO.UpdatedBy,
            employeeDeleteDTO.DeletedBy, employeeDeleteDTO.IsActive, employeeDeleteDTO.IsDeleted,
            employeeDeleteDTO.RoleId, employeeDeleteDTO.TeamId, employeeDeleteDTO.FirstName,
            employeeDeleteDTO.EmployeeMiddleName, employeeDeleteDTO.LastName, employeeDeleteDTO.Email,
            employeeDeleteDTO.Age, employeeDeleteDTO.EmployeeSkills);
    }
}
