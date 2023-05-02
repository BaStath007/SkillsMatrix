using Application.Queries.Common;

namespace Application.Queries.HardSkills.GetHardSkillById;

public sealed record GetHardSkillByIdQuery_1_0(int id) : IQuery<GetHardSkillByIdResponse>;