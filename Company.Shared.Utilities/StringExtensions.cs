namespace Company.Shared.Utilities;

public static class StringExtensions
{
    /// <summary>
    /// Указывает, является ли эта строка нулевой, пустой или состоит только из символов пробелов.
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static bool IsNullOrWhiteSpace(this string? str)
    {
        return string.IsNullOrWhiteSpace(str);
    }
}
