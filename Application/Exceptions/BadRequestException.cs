namespace Application.Exceptions;

public sealed class BadRequestException : Exception
{
    public string[]? Errors { get; set; }
}
