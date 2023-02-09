using AutoMapper;
using BlitzFiles.Data;

namespace BlitzFiles.DataTransfer.Profiles
{
    public class FilePathsProfile : Profile
    {
        public FilePathsProfile()
        {
            CreateMap<FilePath, FilePathDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(fp => fp.Id))
                .ForMember(dto => dto.StorageFileName, opt => opt.MapFrom(fp => fp.StorageFileName))
                .ForMember(dto => dto.FileId, opt => opt.MapFrom(fp => fp.FileId))
                .ForMember(dto => dto.File, opt => opt.MapFrom(fp => fp.File));

            CreateMap<FilePathDTO, FilePath>()
                .ForCtorParam("storageFileName", opt => opt.MapFrom(dto => dto.StorageFileName))
                .ForCtorParam("fileId", opt => opt.MapFrom(dto => dto.FileId))
                .ForMember(fp => fp.Id, opt => opt.MapFrom(dto => dto.StorageFileName));
        }
    }
}
