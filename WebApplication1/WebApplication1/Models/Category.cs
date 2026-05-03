namespace WebApplication1.Models;

public class Category
{
 public int Id { get; set; }
 
 public string Name { get; set; }= null!;
 
 public string Description { get; set; }=null!;

 public DateTime CreatedDate { get; set; }
 
 public DateTime? UpdatedDate { get; set; }
 
 public List<Product>? Products { get; set; }
}