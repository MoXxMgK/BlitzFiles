using AutoMapper;
using BlitzFiles.Data;
using Microsoft.EntityFrameworkCore;
using File = BlitzFiles.Data.File;

namespace BlitzFiles.CQS
{
    public class PatchFileCommandHandler : RequestHandler<FileCommand.Patch, int>
    {
        public PatchFileCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<int> Handle(FileCommand.Patch request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<File>(request.DTO);

            if (entity == null)
                throw new ArgumentException("Request file is null");

            var patchMap = request.PatchList
                .ToDictionary(
                    pm => pm.PropertyName,
                    pm => pm.PropertyValue);

            var entry = db.Entry(entity);
            entry.CurrentValues.SetValues(patchMap);
            entry.State = EntityState.Modified;

            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
