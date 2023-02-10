using AutoMapper;
using BlitzFiles.Data;

using File = BlitzFiles.Data.File;

namespace BlitzFiles.CQS
{
    public class DeleteFileCommandHandler : GenericDeleteCommandHandler<FileCommand.Delete, File>
    {
        public DeleteFileCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
