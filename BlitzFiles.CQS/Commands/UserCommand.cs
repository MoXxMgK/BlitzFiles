using MediatR;
using BlitzFiles.DataTransfer;
using BlitzFiles.Models;

namespace BlitzFiles.CQS
{
    public class UserCommand
    {
        public class Create : GenericCommand.Create<UserDTO> { }

        public class Delete : GenericCommand.Delete<UserDTO> { }

        public class Patch : GenericCommand.Patch<UserDTO> { }
    }
}
