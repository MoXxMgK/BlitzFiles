using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public class GetExpiredFilesQueryHandler : RequestHandler<FileQuery.GetExpired, IEnumerable<FileDTO>>
    {
        public GetExpiredFilesQueryHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<IEnumerable<FileDTO>> Handle(FileQuery.GetExpired request, CancellationToken cancellationToken)
        {
            var files = await db.Files
                .AsNoTracking()
                .Where(f => f.ExpirationDate >= request.ExpireDate)
                .Include(f => f.FilePath)
                .ToListAsync(cancellationToken);

            return mapper.Map<IEnumerable<FileDTO>>(files);
        }
    }
}
