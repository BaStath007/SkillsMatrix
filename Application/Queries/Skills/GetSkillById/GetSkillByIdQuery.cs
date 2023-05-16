using Application.Queries.Common;

namespace Application.Queries.Skills.GetSkillById;

public sealed record GetSkillByIdQuery(Guid Id) : IQuery<GetSkillByIdResponse>;