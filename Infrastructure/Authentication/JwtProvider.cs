using Application.Authentication;
using Application.DTOs.EmployeeDTOs;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Authentication;

public sealed class JwtProvider : IJwtProvider
{
    private readonly IConfiguration _config;

    public JwtProvider(IConfiguration config)
    {
        _config = config;
    }

    public string Generate(EmployeeGetDTO employeeDTO)
    {
        Claim[] claims = new Claim[] 
        {
            new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new(JwtRegisteredClaimNames.Sub, employeeDTO.Id.ToString()),
            new(JwtRegisteredClaimNames.Email, employeeDTO.Email.Value)
        };
        
        SigningCredentials signingCredentials = new(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["JwtSettings:Key"]!)),
            SecurityAlgorithms.HmacSha256);
        
        JwtSecurityToken token = new(
            _config["JwtSettings:Issuer"],
            _config["JwtSettings:Audience"],
            claims,
            null,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);

        string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

        return tokenValue;
    }
}
