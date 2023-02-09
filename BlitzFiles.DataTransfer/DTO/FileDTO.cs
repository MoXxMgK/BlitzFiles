using BlitzFiles.Data;
using BlitzFiles.Models;

namespace BlitzFiles.DataTransfer
{
    public class FileDTO : IDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public long FileSize { get; set; }
        public string FileHash { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsPublic { get; set; }

        public FilePath FilePath { get; set; }

        public Guid? UserId { get; set; }
        public User? User { get; set; }
    }
}
