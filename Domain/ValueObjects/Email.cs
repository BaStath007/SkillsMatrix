using Domain.Primitives;
using Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects;

public sealed class Email : ValueObject
{
    private const int MaxLength = 30;
    public string Value { get; } = string.Empty;

    private Email(string value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Email> Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            return Result<Email>.Failure(new Error(
                "Email.Empty",
                "The Email field is empty."));
        }

        if (email.Length > MaxLength)
        {
            return Result<Email>.Failure(new Error(
                "Email.InvalidLength",
                "The Email's length exceeded the specified max length."));
        }

        return new Email(email);
    }
}
