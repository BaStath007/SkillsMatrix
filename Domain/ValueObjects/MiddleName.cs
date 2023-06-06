using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class MiddleName : ValueObject
{
    private const int MaxLength = 25;
    public string Value { get; } = string.Empty;

    private MiddleName(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<MiddleName> Create(string middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName))
        {
            return Result<MiddleName>.Failure(new Error(
                "MiddleName.Empty",
                "The MiddleName field is empty."));
        }

        if (middleName.Length > MaxLength)
        {
            return Result<MiddleName>.Failure(new Error(
                "MiddleName.InvalidLength",
                "The MiddleName field's length exceeded the specified max length."));
        }

        string capitalizedMiddleName = char.ToUpperInvariant(middleName[0]) + middleName.Substring(1).ToLowerInvariant();
        return new MiddleName(middleName);
    }
}
