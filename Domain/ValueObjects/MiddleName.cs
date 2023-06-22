using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class MiddleName : ValueObject
{
    private const int MaxLength = 25;
    public string Value { get; }

    private MiddleName(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<MiddleName>? Create(string middleName)
    {
        if (string.IsNullOrWhiteSpace(middleName))
        {
            return new MiddleName(string.Empty);
        }
        if (middleName?.Length > MaxLength)
        {
            return new Error(
                "MiddleName.InvalidLength",
                "The MiddleName field's length exceeded the specified max length.");
        }
        if (middleName is not null && middleName != string.Empty)
        {
            string capitalizedMiddleName = char.ToUpperInvariant(middleName[0]) + middleName.Substring(1).ToLowerInvariant() + " ";
            return new MiddleName(capitalizedMiddleName);
        }
        return new MiddleName(string.Empty);
    }
}
