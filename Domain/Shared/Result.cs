namespace Domain.Shared;

public class Result
{
    protected internal Result(bool isSuccess, Error error)
    {
        if ( isSuccess && error != Error.None )
        {
            throw new InvalidOperationException();
        }

        if (!isSuccess && error == Error.None)
        {
            throw new InvalidOperationException();
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success()
    {
        return new(true, Error.None);
    }

    public static Result Failure(Error error)
    {
        return new(false, error);
    }
}


public class Result<TResponse> : Result
{
    private readonly TResponse? _data;
    protected internal Result(bool isSuccess, Error error, TResponse? data)
        :base(isSuccess, error)
    {
        _data = data;
    }

    public TResponse Data => IsSuccess
        ? _data!
        : throw new InvalidOperationException("The value of a failure result cannot be accessed.");

    public static Result<TResponse> Success(TResponse data)
    {
        return new(true, Error.None, data);
    }

    public new static Result<TResponse> Failure(Error error)
    {
        return new(false, error, default);
    }

    private static Result<TResponse> Create(TResponse value)
    {
        return new(true, Error.None, value);
    }

    public static implicit operator Result<TResponse>(TResponse value) => Create(value);
}
