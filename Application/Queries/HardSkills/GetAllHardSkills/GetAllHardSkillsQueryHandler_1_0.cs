﻿using Application.Data.IRepositories;
using Application.DTOs;
using Application.Errors;
using Application.Exceptions;
using Application.Queries.Common;

namespace Application.Queries.HardSkills.GetAllHardSkills;

public sealed class GetAllHardSkillsQueryHandler_1_0 : IQueryHandler<GetAllHardSkillsQuery_1_0, GetAllHardSkillsResponse>
{
    private readonly IHardSkillsRepository _repository;

    public GetAllHardSkillsQueryHandler_1_0(IHardSkillsRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetAllHardSkillsResponse>> Handle(GetAllHardSkillsQuery_1_0 request, CancellationToken cancellationToken)
    {
        try
        {
            var hardSkills = await _repository.GetAll(cancellationToken);

            if (hardSkills == null)
            {
                return Result<GetAllHardSkillsResponse>.Failure(new Error[]
                {
                new Error
                (
                            "HardSkills.NullReference",
                            $"Currently, there are not any hardskills to retrieve from the database." +
                            $"\nPlease try again later."
                        )
                    }
                );
            }
            var response = new GetAllHardSkillsResponse(hardSkills);

            return Result<GetAllHardSkillsResponse>.Success(response);
        }
        catch (BadRequestException ex)
        {
            return Result<GetAllHardSkillsResponse>.Failure(ex.Errors);
        }
    }
}
