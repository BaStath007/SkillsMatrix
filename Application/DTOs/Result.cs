namespace Application.DTOs;

public class Result
{
    internal Result(bool succeeded, IEnumerable<string> errors)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }

    public static Result Success()
    {
        return new Result(true, Array.Empty<string>());
    }

    public static Result Failure(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }
}

public class Result<TResponse> 
{
    internal Result(bool succeeded, IEnumerable<string> errors, TResponse data)
    {
        Succeeded = succeeded;
        Errors = errors.ToArray();
        Data = data;
    }

    public bool Succeeded { get; init; }

    public string[] Errors { get; init; }
    public TResponse Data { get; init; }

    public static Result<TResponse> Success(TResponse data)
    {
        return new Result<TResponse>(true, Array.Empty<string>(), data);
    }

    public static Result<TResponse> Failure(IEnumerable<string> errors)
    {
        return new Result<TResponse>(false, errors, default(TResponse));
    }
}