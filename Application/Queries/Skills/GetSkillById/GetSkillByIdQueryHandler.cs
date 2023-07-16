using Application.Data.IRepositories;
using Application.DTOs.SkillDTOs;
using Application.Exceptions;
using Application.Mapping;
using Application.Queries.Common;
using Domain.Entities;
using Domain.Shared;

namespace Application.Queries.Skills.GetSkillById;

public sealed class GetSkillByIdQueryHandler : IQueryHandler<GetSkillByIdQuery, GetSkillByIdResponse>
{
    private readonly ISkillRepository _repository;

    public GetSkillByIdQueryHandler(ISkillRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetSkillByIdResponse>> Handle(GetSkillByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            SkillGetDTO? skill = await _repository.GetById(request.Id, cancellationToken);

            if (skill == null)
            {
                return new Error(
                            "Skill.NotFound",
                            $"The requested skill with Id: {request.Id} was not found.");
            }
            if (skill.ParentSkillId is not null)
            {
                SkillGetDTO? parentSkill = await _repository.GetById((Guid)skill.ParentSkillId, cancellationToken);
                skill.ParentSkill = SkillExtensions.GetToDomain(parentSkill);
            }

            GetSkillByIdResponse response = new(skill);

            return response;
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }
    }
}
