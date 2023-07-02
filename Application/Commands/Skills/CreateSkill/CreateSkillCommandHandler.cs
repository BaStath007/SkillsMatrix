using Application.Commands.Common;
using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.SkillDTOs;
using Application.Exceptions;
using Domain.Enums;
using Domain.Shared;
using Domain.ValueObjects;

namespace Application.Commands.Skills.CreateSkill;

internal sealed class CreateSkillCommandHandler : ICommandHandler<CreateSkillCommand, Guid>
{
    private readonly ISkillRepository _repository;
    private readonly IUnitOfWork _unit;

    public CreateSkillCommandHandler(ISkillRepository repository, IUnitOfWork unit)
    {
        _repository = repository;
        _unit = unit;
    }

    public async Task<Result<Guid>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {;
        try
        {
            var result = TryCreateValueObjects(request);
            if (result.IsFailure)
            {
                return result.Error;
            }
            
            var skill = SkillCreateDTO.Create
                (
                    request.CreatedBy,
                    request.IsActive,
                    request.ParentSkillId,
                    result.Data,
                    SkillType.FromName(request.SkillType)!,
                    request.ChildrenSkills,
                    request.EmployeeSkills,
                    request.RoleSkills,
                    request.CategoriesPerSkill
                );
            var skillId = _repository.Add(skill);
            await _unit.SaveChangesAsync(cancellationToken);

            return skillId;
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }
    }

    private static Result<Description> TryCreateValueObjects(CreateSkillCommand request)
    {
        var descriptionResult = Description.Create(request.Description);
        
        return descriptionResult!;
    }
}
