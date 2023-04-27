using Abstractions.IRepositories;
using Application.Commands.Common;
using Application.DTOs;
using Domain;

namespace Application.Commands.HardSkills.CreateHardSkill;

internal sealed class CreateHardSkillCommandHandler_1_0 : ICommandHandler<CreateHardSkillCommand_1_0>
{
    private readonly IHardSkillsRepository _HSRepo;

    public CreateHardSkillCommandHandler_1_0(IHardSkillsRepository hSRepo)
    {
        _HSRepo = hSRepo;
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
            request.Category
            );

        _HSRepo.Add(hardSkill);
        await _HSRepo.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
