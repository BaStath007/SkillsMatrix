using Application.Commands.Common;
using Application.Data.IRepositories;
using Application.DTOs;
using Application.Exceptions;
using Domain;

namespace Application.Commands.HardSkills.CreateHardSkill;

internal sealed class CreateHardSkillCommandHandler_1_0 : ICommandHandler<CreateHardSkillCommand_1_0>
{
    private readonly IHardSkillsRepository _repository;

    public CreateHardSkillCommandHandler_1_0(IHardSkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result> Handle(CreateHardSkillCommand_1_0 request, CancellationToken cancellationToken)
    {
        var hardSkill = new HardSkill(
            request.Id,
            request.Name,
            request.Description,
            request.Version,
            request.HardSkills,
            request.Tags,
            request.Categories
            );

        try
        {
            _repository.Add(hardSkill);
            await _repository.SaveChangesAsync(cancellationToken);
        }
        catch (BadRequestException ex)
        {
            return Result.Failure(ex.Errors);
        }

        return Result.Success();
    }
}
