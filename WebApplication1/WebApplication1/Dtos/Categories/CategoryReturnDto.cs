using WebApplication1.Models;

namespace WebApplication1.Dtos.Categories;

public class CategoryReturnDto
{
    public string Name { get; set; }=null!;

    public string Description { get; set; } = null!;
    
    public List<ProductInCategoryReturnDto>? Products { get; set; }
}

public class ProductInCategoryReturnDto
{
    public string Name { get; set; }=null!;
    public string Description { get; set; } = null!;
}