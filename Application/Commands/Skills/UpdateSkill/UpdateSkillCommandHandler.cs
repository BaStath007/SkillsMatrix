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
        if(request.IdProvidedByUser == request.OriginalId)
        {
            var newSkill = new SkillUpdateDTO
                (
                    request.OriginalId,
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
            try
            {
                var oldSkill = await _repository.GetById(request.OriginalId, cancellationToken);
                if (oldSkill == null)
                {
                    return Result.Failure(new Error
                                (
                                   "Skill.NotFound",
                                   $"The requested skill with Id: {request.OriginalId} was not found."
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
        else
        {
            return Result.Failure(new Error
                        (
                           "Skill.IDOR",
                           $"During the execution of your request, it is possible that someone" +
                           $"\ntried to tamper with the skill with Id: {request.OriginalId}." +
                           $"\nThe procedure was terminated before completion for security reasons." +
                           $"\nPlease try again later."
                        )
            );
        }

    }
}