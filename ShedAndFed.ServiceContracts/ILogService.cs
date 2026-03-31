namespace ShedAndFed.ServiceContracts;

public interface ILogService<TCreate, TUpdate, TResponse>
    : ICrudService<TCreate, TUpdate, TResponse, int>
    where TResponse : class
{
    Task<List<TResponse>> GetAllByReptileIdAsync(int reptileId);
}