using BlitzFiles.Models;

namespace BlitzFiles.Core
{
    public interface ICRUDService<T> where T : IDTO
    {
        Task<CRUDResult<T>> GetByIdAsync(Guid id);
        Task<CRUDResult<T>> CreateAsync(T dto);
        Task<CRUDResult<T>> DeleteAsync(Guid id);
        Task<CRUDResult<T>> PatchAsync(Guid id, T dto);
    }
}
