using Application.Commands.Common;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Exceptions;
using Domain.Shared;

namespace Application.Commands.Skills.DeleteSkill;

public sealed class DeleteSkillCommandHandler : ICommandHandler<DeleteSkillCommand>
{
    private readonly ISkillsRepository _repository;

    public DeleteSkillCommandHandler(ISkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var dbSkill = await _repository.GetById(request.Id, cancellationToken);
            if (dbSkill == null)
            {
                return Result.Failure(new Error
                        (
                            "Skill.NotFound",
                            $"The requested skill with Id: {request.Id} was not found."
                        )   
                );
            }

            var skillToDelete = new SkillDeleteDTO(dbSkill.Id, dbSkill.DeletedBy);

            _repository.SoftDelete(skillToDelete);
            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (BadRequestException ex)
        {
            return Result.Failure(ex.Error);
        }
    }
}
