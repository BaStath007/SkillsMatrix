using Application.Commands.Employees.CreateEmployee;
using Application.Commands.Employees.DeleteEmployee;
using Application.Commands.Employees.UpdateEmployee;
using Application.DTOs.EmployeeDTOs;
using Application.Queries.Employees.GetAllEmployees;
using Application.Queries.Employees.GetEmployeeById;
using Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Common;

namespace Presentation.Controllers;

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
        var getAllEmployeesQuery = new GetAllEmployeesQuery();

        var result = await _sender.Send(getAllEmployeesQuery, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpGet("find/{id}")]
    [ProducesResponseType(typeof(EmployeeGetDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetEmployeeByIdQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }

    [HttpPost("register")]
    [ProducesResponseType(typeof(EmployeeCreateDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Post([FromBody] CreateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }

    [HttpPut("modify")]
    [ProducesResponseType(typeof(EmployeeUpdateDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Put([FromBody] UpdateEmployeeCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteEmployeeCommand(id, "Me");

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }
}
