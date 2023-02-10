using AutoMapper;
using BlitzFiles.Data;
using Microsoft.EntityFrameworkCore;
using File = BlitzFiles.Data.File;

namespace BlitzFiles.CQS
{
    public class PatchFileCommandHandler : GenericPatchCommandHandler<FileCommand.Patch, File>
    {
        public PatchFileCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
