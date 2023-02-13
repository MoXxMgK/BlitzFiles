using BlitzFiles.Core;

namespace BlitzFiles.Business
{
    public class LocalFileStorageService : IFileStorageService
    {

        private readonly string StorageFolder = "Files";
        public LocalFileStorageService()
        {
            if (!Directory.Exists(StorageFolder))
            {
                Directory.CreateDirectory(StorageFolder);
            }
        }

        public Task<Stream> GetFileStreamAsync(string fileStorageName)
        {
            throw new NotImplementedException();
        }

        public async Task<string> StoreFileAsync(Stream fileStream)
        {
            string fileName = Path.GetRandomFileName();
            var storagePath = Path.Combine(StorageFolder, fileName);

            using (FileStream fs = new FileStream(storagePath, FileMode.CreateNew))
            {
                await fileStream.CopyToAsync(fs);
            }

            return fileName;
        }
    }
}
