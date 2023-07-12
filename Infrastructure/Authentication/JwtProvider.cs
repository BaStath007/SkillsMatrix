using Application.Abstractions;
using Application.DTOs.EmployeeDTOs;
using System.IdentityModel.Tokens.Jwt;

namespace Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    public string Generate(EmployeeGetDTO employeeDTO)
    {
        JwtSecurityToken token = new(
            "issuer",
            "audience",
            null,
            null,
            DateTime.UtcNow.AddHours(1),
            null);
    }
}
