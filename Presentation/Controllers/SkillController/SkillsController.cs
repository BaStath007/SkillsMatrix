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
    public async Task<IActionResult> Get([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var getHSByIdQuery = new GetSkillByIdQuery(id);

        var result = await _sender.Send(getHSByIdQuery, cancellationToken);

        return result.IsSuccess ? Ok(result.Data) : NotFound(result.Error);
    }


    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Post( CreateSkillCommand Command, CancellationToken cancellationToken)
    {
        //var createSkillCommand = new CreateSkillCommand
        //    (
        //        request.CreatedBy,
        //        request.ParentSkillId,
        //        request.Description,
        //        request.SkillType,
        //        request.ParentSkill,
        //        request.ChildrenSkills,
        //        request.EmployeeSkills,
        //        request.RoleSkills,
        //        request.CategoriesPerSkill
        //    );

        var result = await _sender.Send(Command, cancellationToken);

        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpPut("modify")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] SkillUpdateDTO request, CancellationToken cancellationToken)
    {
        var updateSkillCommand = new UpdateSkillCommand
            (
                id,
                request.Id,
                request.CreatedAt,
                request.UpdatedAt,
                request.DeletedAt,
                request.CreatedBy,
                request.UpdatedBy,
                request.DeletedBy,
                request.IsActive,
                request.IsDeleted,
                request.ParentSkillId,
                request.Description,
                request.SkillType,
                request.ParentSkill,
                request.ChildrenSkills,
                request.EmployeeSkills,
                request.RoleSkills,
                request.CategoriesPerSkill
            );

        var result = await _sender.Send(updateSkillCommand, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }

    [HttpDelete("delete")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesErrorResponseType(typeof(Error))]
    public async Task<IActionResult> Delete([FromQuery] Guid id, CancellationToken cancellationToken)
    {
        var deleteSkillCommand = new DeleteSkillCommand(id);

        var result = await _sender.Send(deleteSkillCommand, cancellationToken);

        return result.IsSuccess ? Ok() : NotFound(result.Error);
    }
}