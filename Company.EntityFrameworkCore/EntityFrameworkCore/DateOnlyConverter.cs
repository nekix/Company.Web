using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Company.EntityFrameworkCore;

/// <summary>
/// Converts <see cref="DateOnly" /> to <see cref="DateTime"/> and vice versa.
/// </summary>
internal class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    /// <summary>
    /// Creates a new instance of this converter.
    /// </summary>
    public DateOnlyConverter() : base(
        d => d.ToDateTime(TimeOnly.MinValue),
        d => DateOnly.FromDateTime(d))
    { }
}