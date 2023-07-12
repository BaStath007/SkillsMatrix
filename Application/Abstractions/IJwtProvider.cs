using Application.DTOs.EmployeeDTOs;

namespace Application.Abstractions;

public interface IJwtProvider
{
    string Generate(EmployeeGetDTO employeeDTO);
}
