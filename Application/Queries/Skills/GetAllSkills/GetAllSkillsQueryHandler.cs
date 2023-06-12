using Application.Data.IRepositories;
using Application.Exceptions;
using Application.Queries.Common;
using Domain.Shared;

namespace Application.Queries.Skills.GetAllSkills;

public sealed class GetAllSkillsQueryHandler : IQueryHandler<GetAllSkillsQuery, GetAllSkillsResponse>
{
    private readonly ISkillRepository _repository;

    public GetAllSkillsQueryHandler(ISkillRepository repository)
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
                return new Error(
                            "Skills.NullReference",
                            $"A error occured while trying to retrieve the skills from the database." +
                            $"\nPlease try again later.");
            }
            var response = new GetAllSkillsResponse(skills);

            return response;
        }
        catch (BadRequestException ex)
        {
            return ex.Error;
        }
    }
}
