using AutoMapper;
using DataGen.App.Infrastructure.Options;
using DataGen.App.ViewModels;

namespace DataGen.App
{
    class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<JsonOptions, JsonViewModel>().ReverseMap();
        }
    }
}
