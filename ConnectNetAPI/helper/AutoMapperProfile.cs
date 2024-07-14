using AutoMapper;
using ConnectNet.Models;
using ConnectNet.Models.DTOs;

namespace ConnectNet.helper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<AppUser, memberDTO>()
                .ForMember(dest=>dest.PhotoUrl, opt=>opt.MapFrom(src=>src.Photos.FirstOrDefault(x=>x.IsMain).Url));
            CreateMap<photos, photosDTO>();

        }
    }
}
