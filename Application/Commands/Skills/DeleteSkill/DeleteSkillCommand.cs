using Application.Commands.Common;

namespace Application.Commands.Skills.DeleteSkill;

public sealed record DeleteSkillCommand(Guid Id, string DeletedBy) : ICommand;
