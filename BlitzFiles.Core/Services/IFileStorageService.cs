namespace BlitzFiles.Core
{
    public interface IFileStorageService
    {
        Task<string> StoreFileAsync(Stream fileStream);
        Task<Stream> GetFileStreamAsync(string fileStorageName);
    }
}
