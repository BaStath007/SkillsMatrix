using Domain.Helpers;
using Domain;
using Application.Commands.Common;

namespace Application.Commands.HardSkills.DeleteHardSkill;

public sealed record DeleteHardSkillCommand_1_0(int id) : ICommand;
