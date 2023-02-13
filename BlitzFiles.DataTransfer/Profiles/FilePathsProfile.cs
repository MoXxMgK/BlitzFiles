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
                .ForMember(fp => fp.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(fp => fp.StorageFileName, opt => opt.MapFrom(dto => dto.StorageFileName))
                .ForMember(fp => fp.FileId, opt => opt.MapFrom(dto => dto.FileId));
        }
    }
}
