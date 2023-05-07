using Application.Commands.Common;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Errors;
using Application.Exceptions;

namespace Application.Commands.HardSkills.DeleteHardSkill;

public sealed class DeleteHardSkillCommandHandler_1_0 : ICommandHandler<DeleteHardSkillCommand_1_0>
{
    private readonly IHardSkillsRepository _repository;

    public DeleteHardSkillCommandHandler_1_0(IHardSkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(DeleteHardSkillCommand_1_0 request, CancellationToken cancellationToken)
    {
        try
        {
            var dbHardSkill = await _repository.GetById(request.id, cancellationToken);
            if (dbHardSkill == null)
            {
                return Result.Failure(new Error[]
                    {
                        new Error
                        (
                            "HardSkill.NotFound",
                            $"The requested hardskill with Id: {request.id} was not found."
                        )

                    }
                );
            }

            var hardSkillToDelete = new HardSkillDeleteDTO
                    (
                        dbHardSkill.Id
                    );

            _repository.Delete(hardSkillToDelete);
            await _repository.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
        catch (BadRequestException ex)
        {
            return Result.Failure(ex.Errors);
        }
    }
}
