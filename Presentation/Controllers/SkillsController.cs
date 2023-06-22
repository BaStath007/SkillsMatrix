using MediatR;
using Application.Shared;
using Application.DTOs.SkillDTOs;
using Application.Queries.Skills.GetAllSkills;
using Application.Queries.Skills.GetSkillById;
using Application.Commands.Skills.CreateSkill;
using Application.Commands.Skills.UpdateSkill;
using Application.Commands.Skills.DeleteSkill;
using Presentation.Controllers.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        var getAllSkillsQuery = new GetAllSkillsQuery();

        var result = await _sender.Send(getAllSkillsQuery, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpGet("find/{id}")]
    [ProducesResponseType(typeof(SkillGetDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Get([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var query = new GetSkillByIdQuery(id);

        var result = await _sender.Send(query, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }


    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Post([FromBody] CreateSkillCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpPut("modify")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Put([FromBody] UpdateSkillCommand command, CancellationToken cancellationToken)
    {

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpDelete("delete/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Delete([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var command = new DeleteSkillCommand(id, "Me");

        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }
}