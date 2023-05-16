using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class FirstName : ValueObject
{
    private const int MaxLength = 25;
    public string Value { get; }

    private FirstName(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<FirstName> Create(string firstName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            return Result<FirstName>.Failure(new Error(
                "FirstName.Empty",
                "The FirstName field is empty."));
        }

        if (firstName.Length > MaxLength)
        {
            return Result<FirstName>.Failure(new Error(
                "FirstName.InvalidLength",
                "The FirstName field's length exceeded the specified max length."));
        }

        string capitalizedFirstName = char.ToUpperInvariant(firstName[0]) + firstName.Substring(1).ToLowerInvariant();
        return new FirstName(firstName);
    }
}
