using MediatR;
using BlitzFiles.DataTransfer;

namespace BlitzFiles.CQS
{
    public class FilePathQuery
    {
        public class GetById : FilePathQuery, IRequest<FilePathDTO>
        {
            public Guid Id { get; set; }
        }

        public class GetByFileId : FilePathQuery, IRequest<FilePathDTO>
        {
            public Guid FileId { get; set; }
        }
    }
}
