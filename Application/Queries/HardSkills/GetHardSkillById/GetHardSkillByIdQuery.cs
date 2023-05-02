using Application.Queries.Common;

namespace Application.Queries.HardSkills.GetHardSkillById;

public sealed record GetHardSkillByIdQuery(int id) : IQuery<GetHardSkillByIdResponse>;