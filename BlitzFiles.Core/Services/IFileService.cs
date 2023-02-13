using BlitzFiles.DataTransfer;
using BlitzFiles.Models;

namespace BlitzFiles.Core
{
    public interface IFileService : ICRUDService<FileDTO>
    {
        Task<CRUDResult<FileDTO>> GetFileByFileHash(string fileHash);
    }
}
