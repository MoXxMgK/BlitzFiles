using AutoMapper;
using BlitzFiles.Data;
using BlitzFiles.Models;
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
                .ForMember(dto => dto.FilePath, opt => opt.MapFrom(f => f.FilePath));

            CreateMap<FileDTO, File>()
                .ForMember(f => f.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(f => f.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(f => f.Extention, opt => opt.MapFrom(dto => dto.Extention))
                .ForMember(f => f.FileSize, opt => opt.MapFrom(dto => dto.FileSize))
                .ForMember(f => f.FileHash, opt => opt.MapFrom(dto => dto.FileHash))
                .ForMember(f => f.UploadDate, opt => opt.MapFrom(dto => dto.UploadDate))
                .ForMember(f => f.ExpirationDate, opt => opt.MapFrom(dto => dto.ExpirationDate));

            CreateMap<FileDTO, FileResponseModel>()
                .ForMember(frm => frm.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(frm => frm.Name, opt => opt.MapFrom(dto => dto.Name))
                .ForMember(frm => frm.Extention, opt => opt.MapFrom(dto => dto.Extention))
                .ForMember(frm => frm.FileSize, opt => opt.MapFrom(dto => dto.FileSize))
                .ForMember(frm => frm.UploadDate, opt => opt.MapFrom(dto => dto.UploadDate))
                .ForMember(frm => frm.ExpirationDate, opt => opt.MapFrom(dto => dto.ExpirationDate));
        }
    }
}
