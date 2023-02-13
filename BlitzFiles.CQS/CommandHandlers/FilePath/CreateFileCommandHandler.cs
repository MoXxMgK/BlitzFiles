using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using File = BlitzFiles.Data.File;

namespace BlitzFiles.CQS
{
    public class CreateFilePathCommandHandler : RequestHandler<FilePathCommand.Create, int>
    {
        public CreateFilePathCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<int> Handle(FilePathCommand.Create request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<FilePath>(request.DTO);

            if (entity == null)
                throw new ArgumentException("Request file is null");

            await db.FilePaths.AddAsync(entity, cancellationToken);
            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
