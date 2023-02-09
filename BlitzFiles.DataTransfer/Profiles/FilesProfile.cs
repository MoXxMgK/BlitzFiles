using AutoMapper;
using BlitzFiles.Data;

using File = BlitzFiles.Data.File;

namespace BlitzFiles.DataTransfer.Profiles
{
    public class FilesProfile : Profile
    {
        public FilesProfile()
        {
            CreateMap<File, FileDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(f => f.Id))
                .ForMember(dto => dto.Name, opt => opt.MapFrom(f => f.Name))
                .ForMember(dto => dto.Extention, opt => opt.MapFrom(f => f.Extention))
                .ForMember(dto => dto.FileSize, opt => opt.MapFrom(f => f.FileSize))
                .ForMember(dto => dto.FileHash, opt => opt.MapFrom(f => f.FileHash))
                .ForMember(dto => dto.UploadDate, opt => opt.MapFrom(f => f.UploadDate))
                .ForMember(dto => dto.ExpirationDate, opt => opt.MapFrom(f => f.ExpirationDate))
                .ForMember(dto => dto.IsPublic, opt => opt.MapFrom(f => f.IsPublic))
                .ForMember(dto => dto.FilePath, opt => opt.MapFrom(f => f.FilePath))
                .ForMember(dto => dto.UserId, opt => opt.MapFrom(f => f.UserId))
                .ForMember(dto => dto.User, opt => opt.MapFrom(f => f.User));

            CreateMap<FileDTO, File>()
                .ForCtorParam("name", opt => opt.MapFrom(dto => dto.Name))
                .ForCtorParam("extention", opt => opt.MapFrom(dto => dto.Extention))
                .ForCtorParam("fileSize", opt => opt.MapFrom(dto => dto.FileSize))
                .ForCtorParam("fileHash", opt => opt.MapFrom(dto => dto.FileHash))
                .ForCtorParam("isPublic", opt => opt.MapFrom(dto => dto.IsPublic))
                .ForMember(f => f.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(f => f.UserId, opt => opt.MapFrom(dto => dto.UserId));
        }
    }
}
