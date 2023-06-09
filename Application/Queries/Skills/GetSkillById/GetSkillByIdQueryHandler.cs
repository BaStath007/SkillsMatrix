using Application.Data.IRepositories;
using Application.Exceptions;
using Application.Queries.Common;
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
            var skill = await _repository.GetById(request.Id, cancellationToken);

            if (skill == null)
            {
                return Result<GetSkillByIdResponse>.Failure(new Error
                    (
                            "Skill.NotFound",
                            $"The requested skill with Id: {request.Id} was not found."
                        )
                );
            }

            var response = new GetSkillByIdResponse(skill);

            return Result<GetSkillByIdResponse>.Success((GetSkillByIdResponse)response);
        }
        catch (BadRequestException ex)
        {
            return Result<GetSkillByIdResponse>.Failure(ex.Error);
        }
    }
}
