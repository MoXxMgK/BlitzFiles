using AutoMapper;
using BlitzFiles.Data;
using File = BlitzFiles.Data.File;

namespace BlitzFiles.CQS
{
    public class DeleteFileCommandHandler : RequestHandler<FileCommand.Delete, int>
    {
        public DeleteFileCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<int> Handle(FileCommand.Delete request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<File>(request.DTO);

            if (entity == null)
                throw new ArgumentException("Request file is null");

            db.Files.Remove(entity);
            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
