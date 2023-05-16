using Domain.Shared;

namespace Application.Exceptions;

public sealed class BadRequestException : Exception
{
    public Error Error { get; private init; }

    private BadRequestException(Error error)
    {
        Error = error;
    }

    public static BadRequestException Create(Error error) => new(error);
}
