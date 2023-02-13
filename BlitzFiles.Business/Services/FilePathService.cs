using AutoMapper;
using BlitzFiles.Core;
using BlitzFiles.CQS;
using BlitzFiles.DataTransfer;
using BlitzFiles.Models;
using MediatR;

namespace BlitzFiles.Business
{
    public class FilePathService : IFilePathService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FilePathService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CRUDResult<FilePathDTO>> CreateAsync(FilePathDTO dto)
        {
            var result = await _mediator.Send(new FilePathCommand.Create()
            {
                DTO = dto
            });

            if (result == 1)
            {
                var filePath = await _mediator.Send(new FilePathQuery.GetById()
                {
                    Id = dto.Id
                });

                return new CRUDResult<FilePathDTO>(dto);
            }
            else
            {
                return new CRUDResult<FilePathDTO>();
            }
        }

        public Task<CRUDResult<FilePathDTO>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CRUDResult<FilePathDTO>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return new CRUDResult<FilePathDTO>();

            var filePath = await _mediator.Send(new FilePathQuery.GetById()
            {
                Id = id
            });

            if (filePath == null)
            {
                return new CRUDResult<FilePathDTO>();
            }
            else
            {
                return new CRUDResult<FilePathDTO>(filePath);
            }
        }

        public Task<CRUDResult<FilePathDTO>> PatchAsync(Guid id, FilePathDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
