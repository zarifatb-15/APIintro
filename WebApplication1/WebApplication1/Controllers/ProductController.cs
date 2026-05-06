using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Dtos.Product;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController (AppDbContext appDbContext, IMapper mapper): ControllerBase
{
    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product=appDbContext.Products.Include(p=>p.Category).FirstOrDefault(p=>p.Id==id);
        if(product==null) return NotFound();
        var productReturnDto=mapper.Map<ProductReturnDto>(product);
        return Ok(productReturnDto);
    }
    
    
    [HttpGet]

    public IActionResult GetProducts()
    {
        var products=appDbContext.Products.Include(p=>p.Category).ToList();
        var productsReturnDto=mapper.Map<List<ProductReturnDto>>(products);
        return Ok(productsReturnDto);
        // var products=appDbContext.Products
        //     .Include(p=>p.Category)
        //     .ToList();
        // return Ok(products);
    }

    [HttpPost]

    public IActionResult AddProduct(ProductCreateDto productcreateDto)
    { 
        var category=appDbContext.Categories.Find(productcreateDto.CategoryId); 
        if(category==null) return BadRequest();
       var product=mapper.Map<Product>(productcreateDto);
       appDbContext.Products.Add(product);
       appDbContext.SaveChanges();
       return Ok(product);
    }


    [HttpPut]

    public IActionResult UpdateProduct(int id,Product product)
    {
        var existingProduct=appDbContext.Products.Find(id);
        if(existingProduct==null) return Ok();

        existingProduct.Name=product.Name;
        existingProduct.Description=product.Description;
        existingProduct.Price=product.Price;
        existingProduct.CategoryId=product.CategoryId;
        existingProduct.UpdatedDate=DateTime.Now;

        appDbContext.SaveChanges();
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteProduct(int id)
    {
        var existingProduct=appDbContext.Products.Find(id);
        if(existingProduct==null) return NotFound();

        appDbContext.Products.Remove(existingProduct);
        appDbContext.SaveChanges();
        return Ok();
    }
}