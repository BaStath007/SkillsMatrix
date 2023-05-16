namespace Application.Shared;

public sealed class Error : IEquatable<Error>
{
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
    public string Code { get; }
    public string Message { get; }

    public bool Equals(Error? other)
    {
        if (other == null)
        {
            return false;
        }

        if (other.GetType() != GetType())
        {
            return false;
        }

        return other.Code == Code && other.Message == Message;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null)
        {
            return false;
        }

        if (obj.GetType() != GetType())
        {
            return false;
        }

        if (obj is not Error error)
        {
            return false;
        }

        return error.Code == Code && error.Message == Message;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 3;
            hash = hash * 13 + Code.GetHashCode();
            hash = hash * 17 + Message.GetHashCode();
            return hash;
        }
    }

    public static implicit operator string(Error error) => error.Code;

    public static bool operator ==(Error? a, Error? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Code == b.Code && a.Message == b.Message;
    }

    public static bool operator !=(Error? a, Error? b)
    {
        return !(a == b);
    }
}
