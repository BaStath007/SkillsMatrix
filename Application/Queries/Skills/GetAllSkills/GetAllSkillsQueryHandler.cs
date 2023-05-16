using Application.Data.IRepositories;
using Application.Exceptions;
using Application.Queries.Common;
using Domain.Shared;

namespace Application.Queries.Skills.GetAllSkills;

public sealed class GetAllSkillsQueryHandler : IQueryHandler<GetAllSkillsQuery, GetAllSkillsResponse>
{
    private readonly ISkillsRepository _repository;

    public GetAllSkillsQueryHandler(ISkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetAllSkillsResponse>> Handle(GetAllSkillsQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var skills = await _repository.GetAll(cancellationToken);

            if (skills == null)
            {
                return Result<GetAllSkillsResponse>.Failure(new Error
                (
                            "Skills.NullReference",
                            $"Currently, there are not any skills to retrieve from the database." +
                            $"\nPlease try again later."
                        )
                );
            }
            var response = new GetAllSkillsResponse(skills);

            return Result<GetAllSkillsResponse>.Success(response);
        }
        catch (BadRequestException ex)
        {
            return Result<GetAllSkillsResponse>.Failure(ex.Error);
        }
    }
}
