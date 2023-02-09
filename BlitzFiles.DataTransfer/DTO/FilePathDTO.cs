using BlitzFiles.Models;

using File = BlitzFiles.Data.File;

namespace BlitzFiles.DataTransfer
{
    public class FilePathDTO : IDTO
    {
        public Guid Id { get; set; }
        public string StorageFileName { get; set; }

        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}
