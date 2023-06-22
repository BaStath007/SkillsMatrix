using Application.Commands.Common;
using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.SkillDTOs;
using Application.Exceptions;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Skills.UpdateSkill;

public sealed class UpdateSkillCommandHandler : ICommandHandler<UpdateSkillCommand>
{
    private readonly ISkillRepository _repository;
    private readonly IUnitOfWork _unit;

    public UpdateSkillCommandHandler(ISkillRepository repository, IUnitOfWork unit)
    {
        _repository = repository;
        _unit = unit;
    }

    public async Task<Result> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var oldSkill = await _repository.GetById(request.Id, cancellationToken);
            if (oldSkill == null)
            {
                return new Error(
                    "Skill.NotFound",
                    $"The requested skill with Id: {request.Id} was not found.");
            }

            var result = TryUpdateValueObjects(request, oldSkill);
            if (result.IsFailure)
            {
                return result;
            }

            var newSkill = SkillUpdateDTO.Create
            (
                oldSkill.Id,
                oldSkill.CreatedAt,
                DateTime.UtcNow,
                oldSkill.DeletedAt,
                oldSkill.CreatedBy,
                request.UpdatedBy,
                oldSkill.DeletedBy,
                request.IsActive,
                oldSkill.IsDeleted,
                request.ParentSkillId,
                oldSkill.Description,
                request.SkillType,
                request.ChildrenSkills,
                request.EmployeeSkills,
                request.RoleSkills,
                request.CategoriesPerSkill
            );

            _repository.Update(newSkill);
            await _unit.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }
    }

    private static Result TryUpdateValueObjects(UpdateSkillCommand request, SkillGetDTO oldSkill)
    {
        if (!DescriptionsMatch(request, oldSkill))
        {
            var descriptionResult = Description.Create(request.Description);
            if (descriptionResult.IsFailure)
            {
                return descriptionResult;
            }
            oldSkill.Description = descriptionResult.Data;
        }
        return Result.Success();
    }

    private static bool DescriptionsMatch(UpdateSkillCommand request, SkillGetDTO oldSkill)
    {
        return oldSkill.Description.Value == request.Description;
    }
}