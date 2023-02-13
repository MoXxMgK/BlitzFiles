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
        private readonly IFilePathService _filePathService;
        private readonly IFileStorageService _fileStorageService;
        private readonly IMapper _mapper;

        public FilesController(IFileService fileService, IMapper mapper, IFilePathService filePathService, IFileStorageService fileStorageService)
        {
            _fileService = fileService;
            _mapper = mapper;
            _filePathService = filePathService;
            _fileStorageService = fileStorageService;
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
        [RequestFormLimits(MultipartBodyLengthLimit = 2000000000L)]
        [RequestSizeLimit(200000000L)]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                var fileStream = file.OpenReadStream();

                var fileHash = fileStream.CreateMD5();

                var fileCheck = await _fileService.GetFileByFileHash(fileHash);

                // File is already on serrver
                if (fileCheck.Result == OperationResult.OK)
                {
                    var model = _mapper.Map<FileResponseModel>(fileCheck.DTO);
                    return Ok(model);
                }

                // ELSE Store new file and send info back to user

                var fileStorageName = await _fileStorageService.StoreFileAsync(fileStream);

                var fileParts = SplitFileName(file.FileName);

                var fileDTO = new FileDTO()
                {
                    Id = Guid.NewGuid(),
                    Name = fileParts.Item1,
                    Extention = fileParts.Item2,
                    FileSize = file.Length,
                    FileHash = fileHash,
                    UploadDate = DateTime.Now,
                    ExpirationDate = DateTime.Now.AddHours(24)
                };

                var filePathDTO = new FilePathDTO()
                {
                    Id = Guid.NewGuid(),
                    StorageFileName = fileStorageName,
                    FileId = fileDTO.Id
                };

                var result = await _fileService.CreateAsync(fileDTO);

                await _filePathService.CreateAsync(filePathDTO);

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

        [NonAction]
        private Tuple<string, string> SplitFileName(string fileName)
        {
            var tokens = fileName.Split(".");
            string name = tokens[0];
            string ext = tokens[^1];

            return new Tuple<string, string>(name, ext);
        }
    }
}
