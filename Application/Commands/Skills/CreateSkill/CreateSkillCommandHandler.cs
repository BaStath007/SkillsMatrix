using Application.Commands.Common;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Exceptions;
using Domain.Shared;

namespace Application.Commands.Skills.CreateSkill;

internal sealed class CreateSkillCommandHandler : ICommandHandler<CreateSkillCommand>
{
    private readonly ISkillsRepository _repository;

    public CreateSkillCommandHandler(ISkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = new SkillCreateDTO
            (
                request.CreatedBy,
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
            _repository.Add(skill);
            await _repository.SaveChangesAsync(cancellationToken);
        }
        catch (BadRequestException ex)
        {
            return Result.Failure(ex.Error);
        }

        return Result.Success();
    }
}
