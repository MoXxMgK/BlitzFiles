using AutoMapper;
using BlitzFiles.Data;

namespace BlitzFiles.DataTransfer.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserDTO>()
                .ForMember(dto => dto.Id, opt => opt.MapFrom(u => u.Id))
                .ForMember(dto => dto.Login, opt => opt.MapFrom(u => u.Login))
                .ForMember(dto => dto.Password, opt => opt.MapFrom(u => u.Password))
                .ForMember(dto => dto.Files, opt => opt.MapFrom(u => u.Files));

            CreateMap<UserDTO, User>()
                .ForCtorParam("login", opt => opt.MapFrom(dto => dto.Login))
                .ForCtorParam("password", opt => opt.MapFrom(dto => dto.Password))
                .ForMember(u => u.Id, opt => opt.MapFrom(dto => dto.Id))
                .ForMember(u => u.Files, opt => opt.MapFrom(dto => dto.Files));
        }
    }
}
