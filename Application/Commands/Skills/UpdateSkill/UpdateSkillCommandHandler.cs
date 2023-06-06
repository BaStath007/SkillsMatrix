using Application.Commands.Common;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Exceptions;
using Domain.Shared;

namespace Application.Commands.Skills.UpdateSkill;

public sealed class UpdateSkillCommandHandler : ICommandHandler<UpdateSkillCommand>
{
    private readonly ISkillsRepository _repository;

    public UpdateSkillCommandHandler(ISkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var newSkill = new SkillUpdateDTO
            (
                request.Id,
                request.CreatedBy,
                request.UpdatedBy,
                request.IsActive,
                request.ParentSkillId,
                request.Description,
                request.SkillType,
                request.ParentSkill,
                request.ChildrenSkills,
                request.EmployeeSkills,
                request.RoleSkills,
                request.CategoriesPerSkill
            );
        try
        {
            var oldSkill = await _repository.GetById(request.Id, cancellationToken);
            if (oldSkill == null)
            {
                return Result.Failure(new Error
                            (
                               "Skill.NotFound",
                               $"The requested skill with Id: {request.Id} was not found."
                            )
                );
            }
            _repository.Update(newSkill);
            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (BadRequestException ex)
        {
            return Result.Failure(ex.Error);
        }
    }
}