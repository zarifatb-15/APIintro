using AutoMapper;
using WebApplication1.Dtos.Categories;
using WebApplication1.Dtos.Product;
using WebApplication1.Models;

namespace WebApplication1.Profiles;

public class MapperProfile:Profile
{
    public MapperProfile()
    {
        CreateMap<CategoryCreatDto, Category>();
        CreateMap<Category, CategoryReturnDto>();
        CreateMap<Product, ProductInCategoryReturnDto>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductReturnDto>();
        CreateMap<Category, CategoryInProductReturnDto>();
        // .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

    }
}