using Application.Commands.Skills.CreateSkill;
using Application.Commands.Skills.DeleteSkill;
using Application.Commands.Skills.UpdateSkill;
using Application.DTOs;
using Application.Queries.Skills.GetAllSkills;
using Application.Queries.Skills.GetSkillById;
using Application.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Common;

namespace Presentation.Controllers.SkillController;

[Route("api/skills")]
public sealed class SkillsController : ApiController
{
    public SkillsController(ISender sender)
        : base(sender)
    {
    }

    [HttpGet("list")]
    [ProducesResponseType(typeof(List<SkillGetDTO>), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var getAllSkillsQuery = new GetAllSkillsQuery();

        var result = await _sender.Send(getAllSkillsQuery, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : BadRequest(result.Error);
    }

    [HttpGet("find")]
    [ProducesResponseType(typeof(SkillGetDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Get([FromQuery] GetSkillByIdQuery query, CancellationToken cancellationToken)
    {
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

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Delete([FromBody] DeleteSkillCommand command, CancellationToken cancellationToken)
    {
        var result = await _sender.Send(command, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }
}