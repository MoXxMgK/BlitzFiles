using AutoMapper;
using BlitzFiles.Data;

namespace BlitzFiles.CQS
{
    public class PatchFilePathCommandHandler : GenericPatchCommandHandler<FilePathCommand.Patch, FilePath>
    {
        public PatchFilePathCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
