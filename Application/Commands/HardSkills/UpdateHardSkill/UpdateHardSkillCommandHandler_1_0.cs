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
        if(request.IdProvidedByUser == request.OriginalId)
        {
            var newHardSkill = new HardSkillUpdateDTO
                (
                    request.OriginalId,
                    request.Name,
                    request.Description,
                    request.Version,
                    request.HardSkills,
                    request.Tags,
                    request.Categories
                );
            try
            {
                var oldHardSkill = await _repository.GetById(request.OriginalId, cancellationToken);
                if (oldHardSkill == null)
                {
                    return Result.Failure(new Error[]
                            {
                                new Error
                                (
                                   "HardSkill.NotFound",
                                   $"The requested hardskill with Id: {request.OriginalId} was not found."
                                )
                            }
                    );
                }
                _repository.Update(newHardSkill);
                await _repository.SaveChangesAsync(cancellationToken);

                return Result.Success();
            }
            catch (BadRequestException ex)
            {
                return Result.Failure(ex.Errors);
            }
        }
        else
        {
            return Result.Failure(new Error[]
                    {
                        new Error
                        (
                           "HardSkill.IDOR",
                           $"During the execution of your request, it is possible that someone" +
                           $"\ntried to tamper with the hardskill with Id: {request.OriginalId}." +
                           $"\nThe procedure was terminated before completion for security reasons." +
                           $"\nPlease try again later."
                        )
                    }
            );
        }

    }
}