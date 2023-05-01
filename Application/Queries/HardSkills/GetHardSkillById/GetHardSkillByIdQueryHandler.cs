using Application.Data.IRepositories;
using Application.DTOs;
using Application.Errors;
using Application.Exceptions;
using Application.Queries.Common;

namespace Application.Queries.HardSkills.GetHardSkillById;

public sealed class GetHardSkillByIdQueryHandler : IQueryHandler<GetHardSkillByIdQuery, HardSkillResponce>
{
    private readonly IHardSkillsRepository _repository;

    public GetHardSkillByIdQueryHandler(IHardSkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<HardSkillResponce>> Handle(GetHardSkillByIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var hardSkill = await _repository.GetById(request.id, cancellationToken);

            if (hardSkill == null)
            {
                return Result<HardSkillResponce>.Failure(new Error[]
                    {
                    new Error
                    (
                            "HardSkill.NotFound",
                            $"The requested hardskill with Id: {request.id} was not found."
                        )
                    }
                );
            }

            var responce = new HardSkillResponce(hardSkill);

            return Result<HardSkillResponce>.Success(responce);
        }
        catch (BadRequestException ex)
        {
            return Result<HardSkillResponce>.Failure(ex.Errors);
        }
    }
}
