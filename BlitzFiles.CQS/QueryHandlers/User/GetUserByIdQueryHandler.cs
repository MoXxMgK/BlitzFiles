using AutoMapper;
using MediatR;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public class GetUserByIdQueryHandler : RequestHandler<UserQuery.GetById, UserDTO>
    {
        public GetUserByIdQueryHandler(IMapper mapper, BlitzFilesContext db) : base(mapper, db)
        {
        }

        public override async Task<UserDTO> Handle(UserQuery.GetById request, CancellationToken cancellationToken)
        {
            var entity = await db.Users.
                AsNoTracking().
                FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            return mapper.Map<UserDTO>(entity);
        }
    }
}
