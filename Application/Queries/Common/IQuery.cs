﻿using Application.DTOs;
using MediatR;

namespace Application.Queries.Common;

public interface IQuery<TResponce> : IRequest<Result<TResponce>>
{
}

