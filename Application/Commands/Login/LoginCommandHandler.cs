using Application.Authentication;
using Application.Commands.Common;
using Application.Data.IRepositories;
using Application.DTOs.EmployeeDTOs;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Login;

public sealed class LoginCommandHandler : ICommandHandler<LoginCommand, string>
{
    private readonly IEmployeeRepository _employeeRepo;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(IEmployeeRepository employeeRepo, IJwtProvider jwtProvider)
    {
        _employeeRepo = employeeRepo;
        _jwtProvider = jwtProvider;
    }

    public async Task<Result<string>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Result<Email> result = TryCreateEmail(request.Email);
        if (result.IsFailure)
        {
            return result.Error;
        }
        List<EmployeeGetDTO> employees = await _employeeRepo.GetAll(cancellationToken);
        EmployeeGetDTO? employee = employees?.Where(e => e.Email.Value == result.Data.Value).FirstOrDefault();
        
        if (employee is null)
        {
            return new Error(
                "Employee.NotFound",
                "Could not log in. Requested employee was not found.");
        }

        string token = _jwtProvider.Generate(employee);

        return token;
    }

    private static Result<Email> TryCreateEmail(string email)
    {
        Result<Email> emailResult = Email.Create(email);
        if (emailResult.IsFailure)
        {
            return emailResult.Error;
        }
        return emailResult;
    }
}
