using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;

namespace BlitzFiles.CQS
{
    public class CreateUserCommandHandler : GenericCreateCommandHandler<UserCommand.Create, User>
    {
        public CreateUserCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
