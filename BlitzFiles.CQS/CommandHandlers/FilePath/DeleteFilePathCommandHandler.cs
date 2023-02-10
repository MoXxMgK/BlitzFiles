using AutoMapper;
using BlitzFiles.Data;

namespace BlitzFiles.CQS
{
    public class DeleteFilePathCommandHandler : GenericDeleteCommandHandler<FilePathCommand.Delete, FilePath>
    {
        public DeleteFilePathCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
