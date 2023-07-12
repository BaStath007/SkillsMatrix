using Application.Commands.Employees.CreateEmployee;
using Application.Commands.Employees.DeleteEmployee;
using Application.Commands.Employees.UpdateEmployee;
using Application.Commands.Login;
using Application.DTOs.EmployeeDTOs;
using Application.Queries.Employees.GetAllEmployees;
using Application.Queries.Employees.GetEmployeeById;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Common;
using Error = Application.Shared.Error;

namespace Presentation.Controllers;

[Authorize]
[Route("api/employees")]
public sealed class EmployeesController : ApiController
{
    public EmployeesController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<EmployeeGetDTO>), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        GetAllEmployeesQuery getAllEmployeesQuery = new();

        Result<GetAllEmployeesResponse> result = await _sender.Send(getAllEmployeesQuery, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpGet("find/{id}")]
    [ProducesResponseType(typeof(EmployeeGetDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        GetEmployeeByIdQuery query = new(id);

        Result<GetEmployeeByIdResponse> result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(EmployeeCreateDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        Result<Guid> result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }

    [HttpPut("modify")]
    [ProducesResponseType(typeof(EmployeeUpdateDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Put([FromBody] UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        Result result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        DeleteEmployeeCommand command = new(id, "Me");

        Result result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }


    // Login Section....................

    public async Task<IActionResult> LoginEmployee([FromBody] LoginCommand loginCommand, CancellationToken cancellationToken)
    {
        Result<string> result = await _sender.Send(loginCommand, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }
}
