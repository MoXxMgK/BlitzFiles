using BlitzFiles.DataTransfer;
using MediatR;

namespace BlitzFiles.CQS
{
    public class FileQuery
    {
        // Doto make this generic
        public class GetById : FileQuery, IRequest<FileDTO>
        {
            public Guid Id { get; set; }
        }

        public class GetExpired : FileQuery, IRequest<IEnumerable<FileDTO>>
        {
            public DateTime ExpireDate { get; set; } = DateTime.Now;
        }
    }
}
