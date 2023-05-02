using Application.DTOs;
using Application.Queries.Common;

namespace Application.Queries.HardSkills.GetAllHardSkills;

public sealed record GetAllHardSkillsQuery() : IQuery<GetAllHardSkillsResponse>;