using Application.Commands.Common;
using Domain;
using Domain.Helpers;

namespace Application.Commands.HardSkills.CreateHardSkill;

public sealed record CreateHardSkillCommand_1_0
    ( 
        string Name, 
        string? Description, 
        string? Version, 
        List<HardSkill>? HardSkills, 
        List<Tag>? Tags, 
        List<HardSkillCategory>? Categories
    ) : ICommand;