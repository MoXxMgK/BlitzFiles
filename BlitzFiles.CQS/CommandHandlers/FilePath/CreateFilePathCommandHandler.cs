using AutoMapper;
using BlitzFiles.Data;

namespace BlitzFiles.CQS
{
    public class CreateFilePathCommandHandler : GenericCreateCommandHandler<FilePathCommand.Create, FilePath>
    {
        public CreateFilePathCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
