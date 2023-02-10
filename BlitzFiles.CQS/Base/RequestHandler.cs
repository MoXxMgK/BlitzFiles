using AutoMapper;
using MediatR;
using BlitzFiles.Data;
using BlitzFiles.DataTransfer;
using Microsoft.EntityFrameworkCore;

namespace BlitzFiles.CQS
{
    public abstract class RequestHandler<TIn, TOut> : IRequestHandler<TIn, TOut> where TIn : IRequest<TOut>
    {
        protected readonly IMapper mapper;
        protected readonly BlitzFilesContext db;

        public RequestHandler(IMapper mapper, BlitzFilesContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public abstract Task<TOut> Handle(TIn request, CancellationToken cancellationToken);
    }
}
