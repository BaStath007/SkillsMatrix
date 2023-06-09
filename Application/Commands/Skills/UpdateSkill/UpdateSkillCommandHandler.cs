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
                return Result.Failure(new Error
                            (
                               "Skill.NotFound",
                               $"The requested skill with Id: {request.Id} was not found."
                            )
                );
            }

            if (oldSkill.Description.Value != request.Description)
            {
                var descriptionResult = Description.Create(request.Description);
                if (descriptionResult.IsFailure)
                {
                    return descriptionResult;
                }
                oldSkill.Description = descriptionResult.Data;
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
            return Result.Failure(ex.Error);
        }
    }
}