using Application.Commands.Skills.CreateSkill;
using Application.Commands.Skills.DeleteSkill;
using Application.Commands.Skills.UpdateSkill;
using Application.DTOs.SkillDTOs;
using Application.Queries.Skills.GetAllSkills;
using Application.Queries.Skills.GetSkillById;
using Domain.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Common;

namespace Presentation.Controllers;


[Route("api/skills")]
public sealed class SkillsController : ApiController
{
    public SkillsController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<SkillGetDTO>), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        GetAllSkillsQuery getAllSkillsQuery = new();

        Result<GetAllSkillsResponse> result = await _sender.Send(getAllSkillsQuery, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpGet("find/{id}")]
    [ProducesResponseType(typeof(SkillGetDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        GetSkillByIdQuery query = new(id);

        Result<GetSkillByIdResponse> result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }


    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Post([FromBody] CreateSkillCommand command, CancellationToken cancellationToken)
    {
        Result<Guid> result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpPut("modify")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Put([FromBody] UpdateSkillCommand command, CancellationToken cancellationToken)
    {

        Result result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        DeleteSkillCommand command = new(id, "Me");

        Result result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }
}