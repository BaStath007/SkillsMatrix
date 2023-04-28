using Domain;
using Domain.Helpers;
using Domain.Versions;

namespace Application.DTOs;

public sealed class HardSkillCreateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string? Version { get; set; }
    public Dictionary<int, HardSkillNode_1_0>? HardSkills { get; set; }
    public List<Tag>? Tags { get; set; }
    public List<HardSkillCategory>? Categories { get; set; }
}
