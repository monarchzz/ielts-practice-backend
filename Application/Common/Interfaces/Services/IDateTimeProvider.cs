namespace Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    DateTime VnNow { get; }

    DateTime UtcNow { get; }
}