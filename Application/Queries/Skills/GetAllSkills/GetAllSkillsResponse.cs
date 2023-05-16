using Application.DTOs;

namespace Application.Queries.Skills.GetAllSkills
{
    public sealed record GetAllSkillsResponse(List<SkillGetDTO> Skills);
}