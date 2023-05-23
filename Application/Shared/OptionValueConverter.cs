using Domain.Shared;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Application.Shared;

public class OptionValueConverter<T> : ValueConverter<Option<T>, T?>
    where T : class
{
    public OptionValueConverter(ConverterMappingHints? mappingHints = null)
        : base(
            v => v.Reduce(null!),
            v => v != null ? Option<T>.Some(v) : Option<T>.None(),
            mappingHints)
    {
    }
}

