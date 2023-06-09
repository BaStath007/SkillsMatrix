using Application.DTOs.SkillDTOs;

namespace Application.Queries.Skills.GetSkillById
{
    public sealed record GetSkillByIdResponse(SkillGetDTO Skill);
}