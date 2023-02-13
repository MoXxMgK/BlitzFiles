using System.Security.Cryptography;

namespace BlitzFiles.Core
{
    public static class FileStreamExtentions
    {
        public static string CreateMD5(this Stream fileStream)
        {
            using (MD5 algo = MD5.Create())
            {
                var hashBytes = algo.ComputeHash(fileStream);
                return Convert.ToHexString(hashBytes);
            }
        }
    }
}
