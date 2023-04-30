using Application.Commands.Common;
using Domain;
using Domain.Helpers;

namespace Application.Commands.HardSkills.UpdateHardSkill;

public sealed record UpdateHardSkillCommand_1_0
    (
        int Id,
        string Name,
        string? Description,
        string? Version,
        List<HardSkill>? HardSkills,
        List<Tag>? Tags,
        List<HardSkillCategory>? Categories
    ) : ICommand;
