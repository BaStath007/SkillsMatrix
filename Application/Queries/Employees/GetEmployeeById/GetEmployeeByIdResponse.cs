using Application.DTOs.EmployeeDTOs;

namespace Application.Queries.Employees.GetEmployeeById;

public sealed record GetEmployeeByIdResponse(EmployeeGetDTO Employee);