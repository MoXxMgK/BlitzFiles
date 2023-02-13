using MediatR;
using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public class GetFileByIdQueryHandler : RequestHandler<FileQuery.GetById, FileDTO>
    {
        public GetFileByIdQueryHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<FileDTO> Handle(FileQuery.GetById request, CancellationToken cancellationToken)
        {
            var entity = await db.Files
                .AsNoTracking()
                .Include(f => f.FilePath)
                .FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);

            return mapper.Map<FileDTO>(entity);
        }
    }
}
