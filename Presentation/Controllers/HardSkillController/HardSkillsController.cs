using Application.Commands.HardSkills.CreateHardSkill;
using Application.Commands.HardSkills.DeleteHardSkill;
using Application.Commands.HardSkills.UpdateHardSkill;
using Application.DTOs;
using Application.Errors;
using Application.Queries.HardSkills.GetAllHardSkills;
using Application.Queries.HardSkills.GetHardSkillById;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Common;

namespace Presentation.Controllers.HardSkillController;

//[ApiController]
[Route("api/hardskills")]
public sealed class HardSkillsController : ApiController
{
    public HardSkillsController(ISender sender) 
        : base(sender)
    {
    }

    [HttpGet("list")]
    [ProducesResponseType(typeof(List<HardSkillGetDTO>), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var getAllHSQuery = new GetAllHardSkillsQuery_1_0();

        var result = await _sender.Send(getAllHSQuery, cancellationToken);

        return result.Succeeded ? Ok(result.Data) : BadRequest(result.Errors);
    }

    [HttpGet("find")]
    [ProducesResponseType(typeof(HardSkillGetDTO), StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Get([FromQuery] int id, CancellationToken cancellationToken)
    {
        var getHSByIdQuery = new GetHardSkillByIdQuery_1_0(id);

        var result = await _sender.Send(getHSByIdQuery, cancellationToken);

        return result.Succeeded ? Ok(result.Data) : NotFound(result.Errors);
    }


    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Post([FromBody] HardSkillCreateDTO request, CancellationToken cancellationToken)
    {
        var createHSCommand = new CreateHardSkillCommand_1_0
            (
            request.Name,
            request.Description,
            request.Version,
            request.HardSkills,
            request.Tags,
            request.Categories
            );

        var result = await _sender.Send(createHSCommand, cancellationToken);

        return result.Succeeded ? Ok() : BadRequest(result.Errors);
    }

    [HttpPut("modify")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Put([FromQuery] int id, [FromBody] HardSkillUpdateDTO request, CancellationToken cancellationToken)
    {
        var updateHSCommand = new UpdateHardSkillCommand_1_0
            (
                id,
                request.Id,
                request.Name,
                request.Description,
                request.Version,
                request.HardSkills,
                request.Tags,
                request.Categories
            );

        var result = await _sender.Send(updateHSCommand, cancellationToken);

        return result.Succeeded ? Ok() : NotFound(result.Errors);
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Delete([FromQuery] int id, CancellationToken cancellationToken)
    {
        var deleteHSCommand = new DeleteHardSkillCommand_1_0(id);

        var result = await _sender.Send(deleteHSCommand, cancellationToken);

        return result.Succeeded ? Ok() : NotFound(result.Errors);
    }
}