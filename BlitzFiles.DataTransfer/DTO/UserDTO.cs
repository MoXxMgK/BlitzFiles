using BlitzFiles.Models;

using File = BlitzFiles.Data.File;

namespace BlitzFiles.DataTransfer
{
    public class UserDTO : IDTO
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public List<File> Files { get; set; }
    }
}
