using Application.Commands.HardSkills.CreateHardSkill;
using Application.Commands.HardSkills.UpdateHardSkill;
using Application.DTOs;
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

    [HttpPost("registerhardskill")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RegisterHardSkill(HardSkillCreateDTO request, CancellationToken cancellationToken)
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
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ModifyHardSkill(HardSkillUpdateDTO request, CancellationToken cancellationToken)
    {
        var updateHSCommand = new UpdateHardSkillCommand_1_0
            (
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