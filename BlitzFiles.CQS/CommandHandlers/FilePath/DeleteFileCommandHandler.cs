using AutoMapper;
using BlitzFiles.Data;
using File = BlitzFiles.Data.File;

namespace BlitzFiles.CQS
{
    public class DeleteFilePathCommandHandler : RequestHandler<FilePathCommand.Delete, int>
    {
        public DeleteFilePathCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<int> Handle(FilePathCommand.Delete request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<FilePath>(request.DTO);

            if (entity == null)
                throw new ArgumentException("Request file is null");

            db.FilePaths.Remove(entity);
            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
