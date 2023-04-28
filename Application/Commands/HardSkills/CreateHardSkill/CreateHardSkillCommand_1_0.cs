using Application.Commands.Common;
using Domain;
using Domain.Helpers;
using Domain.Versions;

namespace Application.Commands.HardSkills.CreateHardSkill;

public sealed record CreateHardSkillCommand_1_0(
    int Id, 
    string Name, 
    string? Description, 
    string? Version, 
    Dictionary<int, HardSkillNode_1_0>? HardSkills, 
    List<Tag>? Tags, 
    HardSkillCategory? Category) : ICommand;