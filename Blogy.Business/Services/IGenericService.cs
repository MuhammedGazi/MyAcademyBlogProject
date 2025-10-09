namespace Blogy.Business.Services
{
    public interface IGenericService<TCreate, TUpdate, TResult>
    {
        Task<List<TResult>> GetAllAsync();
        Task<TUpdate> GetByIdAsync(int id);
        Task CreateAsync(TCreate dto);
        Task UpdateAsync(TUpdate dto);
        Task DeleteAsync(int id);
    }
}
