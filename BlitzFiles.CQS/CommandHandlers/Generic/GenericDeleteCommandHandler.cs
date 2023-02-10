using AutoMapper;
using BlitzFiles.Data;
using MediatR;

namespace BlitzFiles.CQS
{
    public class GenericDeleteCommandHandler<TCommand, TEntity> : RequestHandler<GenericCommand.Delete<TCommand>, int>
        where TCommand : IRequest<int> where TEntity : class, IEntity
    {
        public GenericDeleteCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<int> Handle(GenericCommand.Delete<TCommand> request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<TEntity>(request.DTO);

            if (entity == null)
                throw new ArgumentException($"Delete request of type {nameof(TCommand)} is null");

            var dbSet = db.Set<TEntity>();
            dbSet.Remove(entity);

            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
