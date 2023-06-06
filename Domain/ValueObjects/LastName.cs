using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class LastName : ValueObject
{
    private const int MaxLength = 25;
    public string Value { get; } = string.Empty;

    private LastName(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<LastName> Create(string lastName)
    {
        if (string.IsNullOrWhiteSpace(lastName))
        {
            return Result<LastName>.Failure(new Error(
                "LastName.Empty",
                "The LastName field is empty."));
        }

        if (lastName.Length > MaxLength)
        {
            return Result<LastName>.Failure(new Error(
                "LastName.InvalidLength",
                "The LastName field's length exceeded the specified max length."));
        }

        string capitalizedLastName = char.ToUpperInvariant(lastName[0]) + lastName.Substring(1).ToLowerInvariant();
        return new LastName(lastName);
    }
}