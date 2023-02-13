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

        // Access
        public FilePath? FilePath { get; set; }
    }
}
