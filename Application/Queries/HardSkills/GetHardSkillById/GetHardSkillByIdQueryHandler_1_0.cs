﻿using Application.Data.IRepositories;
using Application.DTOs;
using Application.Errors;
using Application.Exceptions;
using Application.Queries.Common;

namespace Application.Queries.HardSkills.GetHardSkillById;

public sealed class GetHardSkillByIdQueryHandler_1_0 : IQueryHandler<GetHardSkillByIdQuery_1_0, GetHardSkillByIdResponse>
{
    private readonly IHardSkillsRepository _repository;

    public GetHardSkillByIdQueryHandler_1_0(IHardSkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetHardSkillByIdResponse>> Handle(GetHardSkillByIdQuery_1_0 request, CancellationToken cancellationToken)
    {
        try
        {
            var hardSkill = await _repository.GetById(request.id, cancellationToken);

            if (hardSkill == null)
            {
                return Result<GetHardSkillByIdResponse>.Failure(new Error[]
                    {
                    new Error
                    (
                            "HardSkill.NotFound",
                            $"The requested hardskill with Id: {request.id} was not found."
                        )
                    }
                );
            }

            var response = new GetHardSkillByIdResponse(hardSkill);

            return Result<GetHardSkillByIdResponse>.Success(response);
        }
        catch (BadRequestException ex)
        {
            return Result<GetHardSkillByIdResponse>.Failure(ex.Errors);
        }
    }
}