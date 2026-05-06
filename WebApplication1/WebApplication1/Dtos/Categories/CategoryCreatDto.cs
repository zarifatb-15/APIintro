namespace WebApplication1.Dtos.Categories;

public class CategoryCreatDto
{
    public string Name { get; set; } =null!;
    public string Description { get; set; } =null!;
    public IFormFile Photo { get; set; }=null!;
}