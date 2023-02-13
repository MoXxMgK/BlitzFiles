namespace BlitzFiles.Data
{
    public class FilePath : IEntity
    {
        public Guid Id { get; set; }
        public string StorageFileName { get; set; }

        public Guid FileId { get; set; }
        public File File { get; set; }
    }
}
