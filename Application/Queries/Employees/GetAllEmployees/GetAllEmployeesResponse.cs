using Application.DTOs.EmployeeDTOs;

namespace Application.Queries.Employees.GetAllEmployees
{
    public sealed record GetAllEmployeesResponse(List<EmployeeGetDTO> Employees);
}