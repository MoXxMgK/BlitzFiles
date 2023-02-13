using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public class GetFileByFileHashQueryHandler : RequestHandler<FileQuery.GetByFileHash, FileDTO>
    {
        public GetFileByFileHashQueryHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<FileDTO> Handle(FileQuery.GetByFileHash request, CancellationToken cancellationToken)
        {
            var entity = await db.Files
                .AsNoTracking()
                .Include(f => f.FilePath)
                .Where(f => f.FileHash == request.FileHash)
                .FirstOrDefaultAsync();

            return mapper.Map<FileDTO>(entity);
        }
    }
}
