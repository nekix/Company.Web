using Microsoft.Extensions.Logging;

namespace Company.Exceptions;

public interface IHasLogLevel
{
    LogLevel LogLevel { get; }
}
