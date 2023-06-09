using Application.DTOs.SkillDTOs;

namespace Application.Queries.Skills.GetAllSkills
{
    public sealed record GetAllSkillsResponse(List<SkillGetDTO> Skills);
}