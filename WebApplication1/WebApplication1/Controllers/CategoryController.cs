using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
 [Route("api/[controller]")]
 [ApiController]
 
 
public class CategoryController(AppDbContext appDbContext ) : ControllerBase
{
    [HttpGet]
    // GET
    public IActionResult Get()
    {
        var categories=appDbContext.Categories.ToList();
        // return StatusCode(StatusCodes.Status200OK, "Category Get");
        return Ok(categories);
    }

    [HttpGet("{id}")]

    public IActionResult Get(int id)
    {
        var category= appDbContext.Categories.Find(id);
        if (category == null)  return NotFound();
        
        return Ok(category);
    }

    [HttpPost]
    public IActionResult Post(Category category)
    {
        appDbContext.Categories.Add(category);
        appDbContext.SaveChanges();
        // return StatusCode(201, category);
        return Ok(category);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Category category)
    {
        var existingCategory =appDbContext.Categories.Find(id);
        if (existingCategory== null) return NotFound();
        existingCategory.Name = category.Name;
        existingCategory.Description = category.Description;
        existingCategory.UpdatedDate = DateTime.Now;
        appDbContext.SaveChanges();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var category = appDbContext.Categories.Find(id);
        if (category==null) return NotFound();
        appDbContext.Categories.Remove(category);
        appDbContext.SaveChanges();
        return Ok();
    }
}