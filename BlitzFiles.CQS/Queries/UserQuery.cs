using BlitzFiles.DataTransfer;
using MediatR;

namespace BlitzFiles.CQS
{
    public class UserQuery
    {
        public class GetById : UserQuery, IRequest<UserDTO>
        {
            public Guid Id { get; set; }
        }
    }
}
