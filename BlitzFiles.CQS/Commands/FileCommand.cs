using MediatR;
using BlitzFiles.DataTransfer;
using BlitzFiles.Models;

namespace BlitzFiles.CQS
{
    public class FileCommand
    {
        public class Create : GenericCommand.Create<FileDTO> { }

        public class Delete : GenericCommand.Delete<FileDTO> { }

        public class Patch : GenericCommand.Patch<FileDTO> { }
    }
}
