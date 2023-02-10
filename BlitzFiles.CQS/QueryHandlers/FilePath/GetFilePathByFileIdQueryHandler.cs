using MediatR;
using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public class GetFilePathByFileIdQueryHandler : RequestHandler<FilePathQuery.GetByFileId, FilePathDTO>
    {
        public GetFilePathByFileIdQueryHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<FilePathDTO> Handle(FilePathQuery.GetByFileId request, CancellationToken cancellationToken)
        {
            var entity = await db.FilePaths
                .AsNoTracking()
                .FirstOrDefaultAsync(fp => fp.FileId == request.FileId, cancellationToken);

            return mapper.Map<FilePathDTO>(entity);
        }
    }
}
