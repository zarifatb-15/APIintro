using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos.Categories;
using WebApplication1.Extensions;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
 [Route("api/[controller]")]
 [ApiController]
 
 
public class CategoryController(AppDbContext appDbContext, 
    IMapper mapper,
    IValidator<CategoryCreatDto> createValidator
    ) : ControllerBase
{
    [HttpGet]
    // GET
    public IActionResult Get()
    {
        var context = HttpContext.Request;
        var categories=appDbContext.Categories
            .Include(c=>c.Products)
            .ToList();
         var categoryDtos = mapper.Map<List<CategoryReturnDto>>(categories);
        // return StatusCode(StatusCodes.Status200OK, "Category Get");
        return Ok(categoryDtos);
    }

    [HttpGet("{id}")]
    
    public IActionResult Get(int id)
    {
        var category= appDbContext.Categories.Find(id);
        if (category == null)  return NotFound();
        
        return Ok(category);
    }

    [HttpPost]
    public IActionResult Post([FromForm]CategoryCreatDto categoryCreatDto)
    {
        var validationResult = createValidator.Validate(categoryCreatDto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors.Select(error => new
            {
                error.PropertyName,
                error.ErrorMessage
            }));
        }
         var newCategory = mapper.Map<Category>(categoryCreatDto);
             // new Category
        // {
        //     Name = categoryCreatDto.Name,
        //     Description = categoryCreatDto.Description,
        //     CreatedDate = DateTime.Now
        // };
        // newCategory.ImageUrl = categoryCreatDto.Photo.SaveFile("wwwroot/images/");
    
        appDbContext.Categories.Add(newCategory);
        appDbContext.SaveChanges();
        // return StatusCode(201, category);
        return Ok(newCategory);
    }

    [HttpPut("{id}")]
    public IActionResult Put([FromRoute]int id, [FromBody]CategoryUpdateDto categoryUpdateDto)
    {
        var existingCategory =appDbContext.Categories.Find(id);
        if (existingCategory== null) return NotFound();
        mapper.Map(categoryUpdateDto, existingCategory);
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