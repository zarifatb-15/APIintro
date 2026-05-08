using AutoMapper;
using WebApplication1.Dtos.Categories;
using WebApplication1.Dtos.Product;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Profiles;

public class MapperProfile:Profile
{
    public MapperProfile(IHttpContextAccessor httpContextAccessor)
    {
        var httpContext=httpContextAccessor.HttpContext;
        var uriBuilder = new UriBuilder
        {
            Scheme = httpContext.Request.Scheme,
            Host = httpContext.Request.Host.Host,
            Port = httpContext.Request.Host.Port ?? 80
        };
        
        var url=uriBuilder.Uri.AbsoluteUri;
        
        
        
        CreateMap<CategoryCreatDto, Category>()
            .ForMember(dest=>dest.ImageUrl,opt=>opt.MapFrom(src=>src.Photo.SaveFile("wwwroot/images/")));
        CreateMap<Category, CategoryReturnDto>()
            .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => url + "images/" + src.ImageUrl));
        CreateMap<Product, ProductInCategoryReturnDto>();
        CreateMap<CategoryUpdateDto, Category>();
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductReturnDto>();
        CreateMap<Category, CategoryInProductReturnDto>();
        // .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));

    }
}