using Application.Commands.Common;
using Domain;
using Domain.Helpers;
using Domain.Versions;

namespace Application.Commands.HardSkills.CreateHardSkill;

public sealed record CreateHardSkillCommand_1_0 : ICommand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Version { get; set; }
    public Dictionary<int, HardSkillNode_1_0>? HardSkills { get; set; }
    public List<Tag>? Tags { get; set; }
    public HardSkillCategory? Category { get; set; }
}
