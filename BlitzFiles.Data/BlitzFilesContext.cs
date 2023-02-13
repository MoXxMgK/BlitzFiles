using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.Data
{
    public class BlitzFilesContext : DbContext
    {
        public DbSet<File> Files { get; set; }
        public DbSet<FilePath> FilePaths { get; set; }
        public BlitzFilesContext(DbContextOptions<BlitzFilesContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
        }
    }
}
