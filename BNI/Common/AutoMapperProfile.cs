using AutoMapper;
using BNI.Models;
using BNI.Models.ViewModel;

namespace BNI.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<User, RegisterViewModel>().ReverseMap();
        }
    }
}
