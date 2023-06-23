using Application.Commands.Common;
using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.SkillDTOs;
using Application.Exceptions;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Skills.CreateSkill;

internal sealed class CreateSkillCommandHandler : ICommandHandler<CreateSkillCommand>
{
    private readonly ISkillRepository _repository;
    private readonly IUnitOfWork _unit;

    public CreateSkillCommandHandler(ISkillRepository repository, IUnitOfWork unit)
    {
        _repository = repository;
        _unit = unit;
    }

    public async Task<Result> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {

        try
        {
            var descriptionResult = Description.Create(request.Description);
            if(descriptionResult.IsFailure)
            {
                return descriptionResult;
            }
            var skill = SkillCreateDTO.Create
                (
                    request.CreatedBy,
                    request.IsActive,
                    request.ParentSkillId,
                    descriptionResult.Data,
                    request.SkillType,
                    request.ChildrenSkills,
                    request.EmployeeSkills,
                    request.RoleSkills,
                    request.CategoriesPerSkill
                );
            _repository.Add(skill);
            await _unit.SaveChangesAsync(cancellationToken);
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }

        return Result.Success();
    }
}
