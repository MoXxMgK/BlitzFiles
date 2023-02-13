namespace BlitzFiles.Models
{
    public class FileResponseModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Extention { get; set; }
        public long FileSize { get; set; }
        public DateTime UploadDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string DownloadUrl { get; set; }
    }
}
