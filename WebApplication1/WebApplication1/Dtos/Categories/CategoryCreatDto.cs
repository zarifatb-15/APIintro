using WebApplication1.Attributes;

namespace WebApplication1.Dtos.Categories;

public class CategoryCreatDto
{
    public string Name { get; set; } =null!;
    public string Description { get; set; } =null!;
    // [FileTypes("image/jpeg", "image/png", "image/gif")]
    // [FileLength(5)]
    public IFormFile Photo { get; set; }=null!;
}