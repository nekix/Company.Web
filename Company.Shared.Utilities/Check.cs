using System.Diagnostics.CodeAnalysis;

namespace Company.Shared.Utilities;

public static class Check
{
    public static T NotNull<T>(T? value, string parameterName)
    {
        if (value == null)
        {
            throw new ArgumentNullException($"{parameterName} can not be null!", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Проверяет, является ли эта строка нулевой, пустой или состоит только из символов пробелов,
    /// а также является ли её длина допустимой.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="parameterName"></param>
    /// <param name="maxLength"></param>
    /// <param name="minLength"></param>
    /// <returns>Исходная строка в случае успешного прохождения проверок.
    /// В ином случае - исключение.
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    public static string NotNullOrWhiteSpace(
        string? value,
        string parameterName,
        int maxLength = int.MaxValue,
        int minLength = 0)
    {
        if (value.IsNullOrWhiteSpace())
        {
            throw new ArgumentException($"{parameterName} can not be null, empty or white space!", parameterName);
        }

        if (value!.Length > maxLength)
        {
            throw new ArgumentException($"{parameterName} length must be equal to or lower than {maxLength}!", parameterName);
        }

        if (minLength > 0 && value!.Length < minLength)
        {
            throw new ArgumentException($"{parameterName} length must be equal to or bigger than {minLength}!", parameterName);
        }

        return value;
    }

    /// <summary>
    /// Проверяет, указана ли дата,
    /// а также находится ли она в допустимом диапозоне.
    /// </summary>
    /// <param name="date"></param>
    /// <param name="parameterName"></param>
    /// <param name="minDate"></param>
    /// <param name="maxDate"></param>
    /// <returns>Исходная дата в случае успешного прохождения проверок.
    /// В ином случае - исключение.
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    public static DateOnly Range(
        DateOnly? date,
        string parameterName,
        DateOnly minDate,
        DateOnly maxDate)
    {
        if(!date.HasValue)
        {
            throw new ArgumentException($"{parameterName} must have value!", parameterName);
        }

        if(date.Value.CompareTo(minDate) < 0 || date.Value.CompareTo(maxDate) > 0)
        {
            throw new ArgumentException($"{parameterName} is out of range min: {minDate} - max: {maxDate}!", parameterName);
        }

        return date.Value;
    }

    /// <summary>
    /// Проверяет, задано ли число,
    /// а также находится ли его значение в допустимом диапозоне.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="parameterName"></param>
    /// <param name="minimumValue"></param>
    /// <param name="maximumValue"></param>
    /// <returns>Исходное число в случае успешного прохождения проверок.
    /// В ином случае - исключение.
    /// </returns>
    /// <exception cref="ArgumentException"></exception>
    public static double Range(
        double? value,
        string parameterName,
        double minimumValue,
        double maximumValue = double.MaxValue)
    {
        if (!value.HasValue)
        {
            throw new ArgumentException($"{parameterName} must have value!", parameterName);
        }

        if (value.Value < minimumValue || value.Value > maximumValue)
        {
            throw new ArgumentException($"{parameterName} is out of range min: {minimumValue} - max: {maximumValue}", parameterName);
        }

        return value.Value;
    }
}
