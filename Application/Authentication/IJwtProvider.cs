using Application.DTOs.EmployeeDTOs;

namespace Application.Authentication;

public interface IJwtProvider
{
    string Generate(EmployeeGetDTO employeeDTO);
}
