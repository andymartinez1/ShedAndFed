namespace ShedAndFed.ServiceContracts;

public interface ICrudService<TCreate, TUpdate, TResponse, TKey> where TKey : notnull
{
    Task<TResponse> CreateAsync(TCreate request);

    Task<TResponse?> GetByIdAsync(TKey id);

    Task<TResponse?> UpdateAsync(TUpdate request);

    Task<bool> DeleteAsync(TKey id);
}