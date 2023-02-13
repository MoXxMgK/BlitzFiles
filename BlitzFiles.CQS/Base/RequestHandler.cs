using AutoMapper;
using MediatR;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public abstract class RequestHandler<TRequest, TResult> : IRequestHandler<TRequest, TResult> where TRequest : IRequest<TResult>
    {
        protected readonly IMapper mapper;
        protected readonly BlitzFilesContext db;

        public RequestHandler(IMapper mapper, BlitzFilesContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public abstract Task<TResult> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
