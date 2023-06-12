using Application.Queries.Common;

namespace Application.Queries.Employees.GetEmployeeById;

public sealed record GetEmployeeByIdQuery(Guid Id) : IQuery<GetEmployeeByIdResponse>;