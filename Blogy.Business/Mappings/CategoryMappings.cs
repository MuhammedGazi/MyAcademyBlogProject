using AutoMapper;
using Blogy.Business.DTOs.CategoryDtos;
using Blogy.Entity.Entities;

namespace Blogy.Business.Mappings
{
    public class CategoryMappings:Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category,ResultCategoryDto>()  //eğer dtodaki proplar ile entity ile aynı isimde değilse bu şekilde yapman lazım.
                .ForMember(dst=>dst.CategoryName,
                o=>o.MapFrom(src=>src.Name));
            CreateMap<Category,CreateCategoryDto>().ReverseMap();
            CreateMap<Category,UpdateCategoryDto>().ReverseMap();
        }
    }
}
