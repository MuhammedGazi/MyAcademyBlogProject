using AutoMapper;
using Blogy.Business.DTOs.UserDtos;
using Blogy.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.Business.Mappings
{
    internal class UserMappings:Profile
    {
        public UserMappings()
        {
            CreateMap<AppUser, ResultUserDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => string.Join(" ", src.FirtName, src.LastName)));
            //ResultUserDto içinde FullName için işlem yapacağımı bunun içine de appuserde gelen firstname ve lastname yi birleştir maple diyoruz
        }
    }
}
