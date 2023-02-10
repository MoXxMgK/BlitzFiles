using MediatR;
using BlitzFiles.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public class GenericPatchCommandHandler<TCommand, TEntity> : RequestHandler<GenericCommand.Patch<TCommand>, int>
        where TCommand : IRequest<int> where TEntity : class, IEntity
    {
        public GenericPatchCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<int> Handle(GenericCommand.Patch<TCommand> request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<TEntity>(request.DTO);

            if (entity == null)
                throw new ArgumentException($"Patch requst or type {nameof(TCommand)} is null");

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
