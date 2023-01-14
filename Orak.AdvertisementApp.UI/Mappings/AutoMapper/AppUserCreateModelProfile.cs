using AutoMapper;
using Orak.AdvertisementApp.Business.Mappings.AutoMapper;
using Orak.AdvertisementApp.Dtos;
using Orak.AdvertisementApp.UI.Models;

namespace Orak.AdvertisementApp.UI.Mappings.AutoMapper
{
    public class AppUserCreateModelProfile : Profile
    {
        public AppUserCreateModelProfile()
        {
            CreateMap<AppUserCreateModel, AppUserCreateDto>();
        }
     
    }
}
