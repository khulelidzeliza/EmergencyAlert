using AutoMapper;
using EmergencyAlert.DTO;
using EmergencyAlert.Models;
using EmergencyAlert.Request;

namespace EmergencyAlert.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User , AddUser>().ReverseMap();
            CreateMap<User, UpdateUsersNameDTO>().ReverseMap();
            CreateMap<User, UsersNamesDto>().ReverseMap();

            CreateMap<Volunteer , AddVolunteer>().ReverseMap();
            CreateMap<Volunteer,UpdateVolunteerDto > ().ReverseMap();
            CreateMap<Volunteer, VolunteersDetailDto>()
             .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
             .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
             .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.User.PhoneNumber))
             .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.User.Location));

            CreateMap< EmergencyEvent , AddEmergencyEvent >().ReverseMap();
            CreateMap<EmergencyEvent, EmEventDetailDto>().ReverseMap();
        }
    }
}
