using MediatR;
using AutoMapper;
using BlitzFiles.Data;

namespace BlitzFiles.CQS
{
    public class GenericCreateCommandHandler<TCommand, TEntity> : RequestHandler<GenericCommand.Create<TCommand>, int>
        where TCommand : IRequest<int> where TEntity : class, IEntity
    {
        public GenericCreateCommandHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<int> Handle(GenericCommand.Create<TCommand> request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<TEntity>(request.DTO);

            if (entity == null)
                throw new ArgumentException($"Create requst or type {nameof(TCommand)} is null");

            var dbSet = db.Set<TEntity>();
            await dbSet.AddAsync(entity, cancellationToken);
            return await db.SaveChangesAsync(cancellationToken);
        }
    }
}
