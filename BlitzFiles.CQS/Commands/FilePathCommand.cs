using MediatR;
using BlitzFiles.DataTransfer;
using BlitzFiles.Models;

namespace BlitzFiles.CQS
{
    public class FilePathCommand
    {
        public class Create : GenericCommand.Create<FilePathDTO> { }

        public class Delete : GenericCommand.Delete<FilePathDTO> { }

        public class Patch: GenericCommand.Patch<FilePathDTO> { }
    }
}
