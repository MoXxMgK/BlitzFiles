using MediatR;
using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public class GetFilePathById : RequestHandler<FilePathQuery.GetById, FilePathDTO>
    {
        public GetFilePathById(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<FilePathDTO> Handle(FilePathQuery.GetById request, CancellationToken cancellationToken)
        {
            var entity = await db.FilePaths
                .AsNoTracking()
                .Include(fp => fp.File)
                .FirstOrDefaultAsync(fp => fp.Id == request.Id);

            return mapper.Map<FilePathDTO>(entity);
        }
    }
}
