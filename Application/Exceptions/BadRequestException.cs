using Application.Errors;

namespace Application.Exceptions;

public sealed class BadRequestException : Exception
{
    public Error[]? Errors { get; set; }
}
