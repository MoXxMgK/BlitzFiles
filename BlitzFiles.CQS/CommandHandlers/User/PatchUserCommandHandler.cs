using AutoMapper;
using BlitzFiles.Data;

namespace BlitzFiles.CQS
{
    public class PatchUserCommandHandler : GenericPatchCommandHandler<UserCommand.Patch, User>
    {
        public PatchUserCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
