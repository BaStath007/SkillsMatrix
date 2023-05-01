using Application.DTOs;
using MediatR;

namespace Application.Queries.Common;

public interface IQueryHandler<TQuery, TResponce> : IRequestHandler<TQuery, Result<TResponce>>
    where TQuery : IQuery<TResponce>
{
}
