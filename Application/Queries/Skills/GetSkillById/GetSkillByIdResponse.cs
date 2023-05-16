using Application.DTOs;

namespace Application.Queries.Skills.GetSkillById
{
    public sealed record GetSkillByIdResponse(SkillGetDTO Skill);
}