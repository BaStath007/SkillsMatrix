using Application.Errors;

namespace Application.DTOs;

public class Result
{
    internal Result(bool succeeded, Error[]? errors)
    {
        Succeeded = succeeded;
        Errors = errors;
    }

    public bool Succeeded { get; init; }

    public Error[]? Errors { get; init; }

    public static Result Success()
    {
        return new Result(true, Array.Empty<Error>());
    }

    public static Result Failure(Error[]? errors)
    {
        return new Result(false, errors);
    }
}

public class Result<TResponse> 
{
    internal Result(bool succeeded, string[]? errors, TResponse? data)
    {
        Succeeded = succeeded;
        Errors = errors;
        Data = data;
    }

    public bool Succeeded { get; init; }

    public string[]? Errors { get; init; }
    public TResponse? Data { get; init; }

    public static Result<TResponse> Success(TResponse data)
    {
        return new Result<TResponse>(true, Array.Empty<string>(), data);
    }

    public static Result<TResponse> Failure(string[]? errors)
    {
        return new Result<TResponse>(false, errors, default(TResponse));
    }
}