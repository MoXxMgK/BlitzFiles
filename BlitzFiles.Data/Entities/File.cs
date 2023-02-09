namespace BlitzFiles.Data
{
    public class File : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }  // Uploaded file name
        public string Extention { get; set; }  // File extentions without dot
        public long FileSize { get; set; }  // In bytes
        public string FileHash { get; set; }  // For preventing file duplication with same content
        public DateTime UploadDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool IsPublic { get; set; }

        // Access
        public FilePath FilePath { get; set; }

        // Owner
        public Guid? UserId { get; set; }
        public User? User { get; set; }

        public File(string name, string extention, long fileSize, 
            string fileHash, bool isPublic = false)
        {
            Id = new Guid();
            Name = name;
            Extention = extention;
            FileSize = fileSize;
            FileHash = fileHash;
            UploadDate = DateTime.Now;
            ExpirationDate = UploadDate.AddHours(24);
            IsPublic = isPublic;
        }
    }
}
