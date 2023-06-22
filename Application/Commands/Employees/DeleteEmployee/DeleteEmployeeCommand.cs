using Application.Commands.Common;

namespace Application.Commands.Employees.DeleteEmployee;

public sealed record DeleteEmployeeCommand(Guid Id, string DeletedBy) : ICommand;
