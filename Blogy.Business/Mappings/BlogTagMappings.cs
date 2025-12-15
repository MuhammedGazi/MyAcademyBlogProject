using AutoMapper;
using Blogy.Business.DTOs.BlogDtos;
using Blogy.Business.DTOs.BlogTagDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class BlogTagMappings : Profile
    {
        public BlogTagMappings()
        {
            CreateMap<UpdateBlogTagDto, BlogTag>().ReverseMap();
            CreateMap<CreateBlogTagDto, BlogTag>().ReverseMap();
            CreateMap<ResultBlogTagDto, BlogTag>().ReverseMap();
        }
    }
}
