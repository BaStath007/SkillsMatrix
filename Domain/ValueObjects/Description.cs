using Domain.Primitives;
using Domain.Shared;
using System.Xml.Linq;

namespace Domain.ValueObjects;

public sealed class Description : ValueObject
{
    private const int MaxLength = 50;
    public string Value;

    private Description(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Description> Create(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            return Result<Description>.Failure(new Error(
                "Description.Empty",
                "The Description field is empty."));
        }

        if (description.Length > MaxLength)
        {
            return Result<Description>.Failure(new Error(
                "Description.InvalidLength",
                "The Description's length exceeded the specified max length."));
        }

        return new Description(description);
    }
}
