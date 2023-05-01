using Application.Commands.HardSkills.CreateHardSkill;
using Application.Commands.HardSkills.UpdateHardSkill;
using Application.DTOs;
using Application.Errors;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Controllers.Common;

namespace Presentation.Controllers.HardSkillController;

[Route("api/hardskills")]
public sealed class HardSkillsController : ApiController
{
    public HardSkillsController(ISender sender) 
        : base(sender)
    {
    }

    [HttpGet("findhardskillbyid")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {

    }


    [HttpPost("registerhardskill")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Create(HardSkillCreateDTO request, CancellationToken cancellationToken)
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

    [HttpPut("modifyhardskill")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Update(int id, HardSkillUpdateDTO request, CancellationToken cancellationToken)
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
}