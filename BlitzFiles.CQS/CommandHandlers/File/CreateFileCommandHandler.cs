using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using File = BlitzFiles.Data.File;

namespace BlitzFiles.CQS
{
    public class CreateFileCommandHandler : RequestHandler<FileCommand.Create, int>
    {
        public CreateFileCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<int> Handle(FileCommand.Create request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<File>(request.DTO);

            if (entity == null)
                throw new ArgumentException("Request file is null");

            await db.Files.AddAsync(entity, cancellationToken);
            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
