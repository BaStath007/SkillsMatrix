using Application.DTOs;

namespace Application.Queries.HardSkills.GetAllHardSkills
{
    public sealed record GetAllHardSkillsResponse(List<HardSkillGetDTO> hardSkills);
}