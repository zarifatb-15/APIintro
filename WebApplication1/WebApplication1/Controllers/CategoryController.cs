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
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }
}