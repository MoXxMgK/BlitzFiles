using BlitzFiles.DataTransfer;
using MediatR;

namespace BlitzFiles.CQS
{
    public class FileQuery
    {
        // Doto make this generic
        public class GetById : IRequest<FileDTO>
        {
            public Guid Id { get; set; }
        }

        public class GetByFileHash : IRequest<FileDTO>
        {
            public string FileHash { get; set; }
        }

        public class GetExpired : IRequest<IEnumerable<FileDTO>>
        {
            public DateTime ExpireDate { get; set; } = DateTime.Now;
        }
    }
}
