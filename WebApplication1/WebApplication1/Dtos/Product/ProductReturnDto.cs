using WebApplication1.Models;

namespace WebApplication1.Dtos.Product;

public class ProductReturnDto
{
    public string Name { get; set; }=null!;
    public string Description { get; set; } =null!;
    public decimal Price { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public CategoryInProductReturnDto Category { get; set; } = null!;
}

public class CategoryInProductReturnDto
{
    public int Id { get; set; }
    public string Name { get; set; }=null!;
    public string Description { get; set; } =null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}