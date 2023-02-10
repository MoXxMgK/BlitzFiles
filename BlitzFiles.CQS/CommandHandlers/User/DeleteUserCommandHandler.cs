using AutoMapper;
using BlitzFiles.Data;

namespace BlitzFiles.CQS
{
    public class DeleteUserCommandHandler : GenericDeleteCommandHandler<UserCommand.Delete, User>
    {
        public DeleteUserCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
