using MediatR;
using BlitzFiles.DataTransfer;

namespace BlitzFiles.CQS
{
    public class FilePathQuery
    {
        public class GetById : IRequest<FilePathDTO>
        {
            public Guid Id { get; set; }
        }

        public class GetByFileId : IRequest<FilePathDTO>
        {
            public Guid FileId { get; set; }
        }
    }
}
