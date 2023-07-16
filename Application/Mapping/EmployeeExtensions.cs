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
            employee.IsDeleted, employee.PositionId, employee.TeamId,
            employee.FirstName, employee.EmployeeMiddleName.Map(x => x).Reduce(MiddleName.Create(string.Empty)!.Data),
            employee.LastName, employee.Email, employee.Age, employee.Skills);
    }

    public static List<EmployeeGetDTO> GetAllEmployeesToApplication(List<Employee> employees)
    {
        var employeeDTOs = new List<EmployeeGetDTO>();
        foreach (var employee in employees)
        {
            var employeeDTO = EmployeeGetDTO.Create(
            employee.Id, employee.CreatedAt, employee.UpdatedAt, employee.DeletedAt,
            employee.CreatedBy, employee.UpdatedBy, employee.DeletedBy, employee.IsActive,
            employee.IsDeleted, employee.PositionId, employee.TeamId, employee.FirstName,
            employee.EmployeeMiddleName.Map(x => x).Reduce(MiddleName.Create(string.Empty)!.Data),
            employee.LastName, employee.Email, employee.Age, employee.Skills);
            employeeDTOs.Add(employeeDTO);
        }
        return employeeDTOs;
    }

    public static Employee CreateToDomain(EmployeeCreateDTO employeeCreateDTO)
    {
        Employee employee = Employee.Create(employeeCreateDTO.CreatedBy, employeeCreateDTO.IsActive, employeeCreateDTO.RoleId,
            employeeCreateDTO.TeamId, employeeCreateDTO.FirstName, employeeCreateDTO.EmployeeMiddleName,
            employeeCreateDTO.LastName, employeeCreateDTO.Email, employeeCreateDTO.Age);
        return employee;
    }

    public static Employee UpdateToDomain(EmployeeUpdateDTO employeeUpdateDTO)
    {
        return Employee.Update(employeeUpdateDTO.Id, employeeUpdateDTO.CreatedAt, employeeUpdateDTO.UpdatedAt,
            employeeUpdateDTO.DeletedAt, employeeUpdateDTO.CreatedBy, employeeUpdateDTO.UpdatedBy,
            employeeUpdateDTO.DeletedBy, employeeUpdateDTO.IsActive, employeeUpdateDTO.IsDeleted,
            employeeUpdateDTO.PositionId, employeeUpdateDTO.TeamId, employeeUpdateDTO.FirstName,
            employeeUpdateDTO.EmployeeMiddleName, employeeUpdateDTO.LastName, employeeUpdateDTO.Email,
            employeeUpdateDTO.Age);
    }

    public static Employee DeleteToDomain(EmployeeDeleteDTO employeeDeleteDTO)
    {
        return Employee.Delete(employeeDeleteDTO.Id, employeeDeleteDTO.CreatedAt, employeeDeleteDTO.UpdatedAt,
            employeeDeleteDTO.DeletedAt, employeeDeleteDTO.CreatedBy, employeeDeleteDTO.UpdatedBy,
            employeeDeleteDTO.DeletedBy, employeeDeleteDTO.IsActive, employeeDeleteDTO.IsDeleted,
            employeeDeleteDTO.PositionId, employeeDeleteDTO.TeamId, employeeDeleteDTO.FirstName,
            employeeDeleteDTO.EmployeeMiddleName, employeeDeleteDTO.LastName, employeeDeleteDTO.Email,
            employeeDeleteDTO.Age, employeeDeleteDTO.Skills!);
    }
}
