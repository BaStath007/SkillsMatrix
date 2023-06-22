using Domain.ValueObjects;

namespace Domain.Shared;

public static class StringExtensions
{
    public static string CreateMiddleName(Option<MiddleName> employeeMiddleName)
    {
        var result = MiddleName.Create(employeeMiddleName.Map(name => name.Value).Reduce(string.Empty));
        if (result!.IsFailure)
        {
            return string.Empty;
        }
        if (result.Data.Value == string.Empty)
        {
            return $"{result.Data.Value}";
        }
        return $"{result.Data.Value} ";
    }
}
