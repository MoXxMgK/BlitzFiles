using AutoMapper;
using BlitzFiles.Core;
using BlitzFiles.DataTransfer;
using BlitzFiles.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlitzFiles.API.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileService _fileService;
        private readonly IMapper _mapper;

        public FilesController(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FileResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Nullable), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFile(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    return BadRequest();
                }

                var result = await _fileService.GetByIdAsync(id);

                if (result.Result == Models.OperationResult.OK)
                {
                    var responseModel = _mapper.Map<FileResponseModel>(result.DTO);
                    return Ok(responseModel);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                // Use serilog here
                var errorModel = new ErrorModel()
                {
                    Message = "Some error occures while fetching file data",
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                return Problem(detail: errorModel.Message, statusCode: errorModel.StatusCode);
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(FileResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorModel), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var fileDTO = new FileDTO()
                {
                    Name = file.Name,
                    Extention = "file",
                    FileSize = file.Length,
                    FileHash = "123test",
                    IsPublic = false
                };

                var result = await _fileService.CreateAsync(fileDTO);

                if (result.Result == OperationResult.OK)
                {
                    var model = _mapper.Map<FileResponseModel>(result.DTO);
                    return Ok(model);
                }
                else
                {
                    return BadRequest("Can not upload file to server");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                System.Diagnostics.Debug.WriteLine(ex.StackTrace);
                // Use serilog here
                var errorModel = new ErrorModel()
                {
                    Message = "Some error occures while uploading file",
                    StatusCode = StatusCodes.Status500InternalServerError
                };

                return Problem(detail: errorModel.Message, statusCode: errorModel.StatusCode);
            }
        }
    }
}
