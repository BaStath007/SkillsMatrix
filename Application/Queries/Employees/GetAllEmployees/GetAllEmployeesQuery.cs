using Application.Queries.Common;

namespace Application.Queries.Employees.GetAllEmployees;

public sealed record GetAllEmployeesQuery() : IQuery<GetAllEmployeesResponse>;