using Domain.Primitives;
using Domain.Shared;

namespace Domain.ValueObjects;

public sealed class Age : ValueObject
{
    private const int MinAge = 16;
    private const int MaxAge = 65;

    public int Value { get; }

    private Age(int value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static Result<Age> Create(int age)
    {
        if (age <= 0)
        {
            return new Error(
                "Age.NotPositive",
                "The Age is not a positive number.");
        }

        if (age < MinAge || age > MaxAge)
        {
            return new Error(
                "Age.OutOfBounds",
                "The Age's value is outside the predefined range.");
        }

        return new Age(age);
    }
}
