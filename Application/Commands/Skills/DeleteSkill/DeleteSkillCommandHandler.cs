using Application.Commands.Common;
using Application.Data;
using Application.Data.IRepositories;
using Application.DTOs.SkillDTOs;
using Application.Exceptions;
using Domain.Shared;

namespace Application.Commands.Skills.DeleteSkill;

public sealed class DeleteSkillCommandHandler : ICommandHandler<DeleteSkillCommand>
{
    private readonly ISkillRepository _repository;
    private readonly IUnitOfWork _unit;

    public DeleteSkillCommandHandler(ISkillRepository repository, IUnitOfWork unit)
    {
        _repository = repository;
        _unit = unit;
    }

    public async Task<Result> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        try
        {
            SkillGetDTO? dbSkill = await _repository.GetById(request.Id, cancellationToken);
            if (dbSkill == null)
            {
                return Result.Failure(new Error
                        (
                            "Skill.NotFound",
                            $"The requested skill with Id: {request.Id} was not found."
                        )   
                );
            }

            SkillDeleteDTO skillToDelete = SkillDeleteDTO.Create
                (
                    dbSkill.Id,
                    dbSkill.CreatedAt,
                    dbSkill.UpdatedAt,
                    dbSkill.CreatedBy,
                    dbSkill.UpdatedBy,
                    request.DeletedBy,
                    dbSkill.ParentSkillId,
                    dbSkill.Description,
                    dbSkill.SkillType,
                    dbSkill.ChildrenSkills,
                    dbSkill.Employees,
                    dbSkill.Positions,
                    dbSkill.SkillCategories
                 );

            _repository.SoftDelete(skillToDelete);
            await _unit.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (BadRequestException ex)
        {
            return Result.Failure(ex.Error);
        }
    }
}
