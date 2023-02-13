using AutoMapper;
using BlitzFiles.Core;
using BlitzFiles.CQS;
using BlitzFiles.DataTransfer;
using BlitzFiles.Models;
using MediatR;

namespace BlitzFiles.Business
{
    public class FileService : IFileService
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public FileService(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<CRUDResult<FileDTO>> CreateAsync(FileDTO dto)
        {
            int result = await _mediator.Send(new FileCommand.Create()
            {
                DTO = dto
            });

            if (result == 1)
            {
                var file = await _mediator.Send(new FileQuery.GetById()
                {
                    Id = dto.Id
                });

                return new CRUDResult<FileDTO>(file);
            }
            else
            {
                return new CRUDResult<FileDTO>();
            }
        }

        public Task<CRUDResult<FileDTO>> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<CRUDResult<FileDTO>> GetByIdAsync(Guid id)
        {
            if (id == Guid.Empty)
                return new CRUDResult<FileDTO>();

            var dto = await _mediator.Send(new FileQuery.GetById()
            {
                Id = id
            });

            if (dto == null)
            {
                return new CRUDResult<FileDTO>();
            }
            else
            {
                return new CRUDResult<FileDTO>(dto);
            }
        }

        public async Task<CRUDResult<FileDTO>> GetFileByFileHash(string fileHash)
        {
            var dto = await _mediator.Send(new FileQuery.GetByFileHash()
            {
                FileHash = fileHash
            });

            if (dto == null)
            {
                return new CRUDResult<FileDTO>();
            }
            else
            {
                return new CRUDResult<FileDTO>(dto);
            }
        }

        public Task<CRUDResult<FileDTO>> PatchAsync(Guid id, FileDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
