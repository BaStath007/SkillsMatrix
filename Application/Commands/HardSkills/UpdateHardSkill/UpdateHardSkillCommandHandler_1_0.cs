using Application.Commands.Common;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Errors;
using Application.Exceptions;

namespace Application.Commands.HardSkills.UpdateHardSkill;

public sealed class UpdateHardSkillCommandHandler_1_0 : ICommandHandler<UpdateHardSkillCommand_1_0>
{
    private readonly IHardSkillsRepository _repository;

    public UpdateHardSkillCommandHandler_1_0(IHardSkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(UpdateHardSkillCommand_1_0 request, CancellationToken cancellationToken)
    {
        var newHardSkill = new HardSkillUpdateDTO
            (
                request.Id,
                request.Name,
                request.Description,
                request.Version,
                request.HardSkills,
                request.Tags,
                request.Categories
            );

        var oldHardSkill = await _repository.GetById(request.Id);
        if (oldHardSkill == null)
        {
            return Result.Failure(new Error[]
                    {
                        new Error
                        (
                           "HardSkill.NotFound",
                           $"The hardskill with Id {request.Id} was not found."
                        )
                    }
                );
        }
        try
        {
            _repository.Update(newHardSkill);
            await _repository.SaveChangesAsync(cancellationToken);

        }
        catch (BadRequestException ex)
        {
            return Result.Failure(ex.Errors);
        }

        return Result.Success();
    }
}