using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using File = BlitzFiles.Data.File;

namespace BlitzFiles.CQS
{
    public class CreateFileCommandHandler : GenericCreateCommandHandler<FileCommand.Create, File>
    {
        public CreateFileCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }
    }
}
