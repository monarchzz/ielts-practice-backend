namespace Application.Common.Interfaces.Persistence;

public interface IBaseRepository
{
    Task SaveChangesAsync();
}