using Application.Queries.Common;

namespace Application.Queries.Skills.GetAllSkills;

public sealed record GetAllSkillsQuery() : IQuery<GetAllSkillsResponse>;