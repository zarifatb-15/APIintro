using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ProductController (AppDbContext appDbContext): ControllerBase
{
    [HttpGet]

    public IActionResult GetProducts()
    {
        var products=appDbContext.Products.ToList();
        return Ok(products);
    }

    [HttpPost]

    public IActionResult AddProduct(Product product)
    {
       appDbContext.Products.Add(product);
       appDbContext.SaveChanges();
       return Ok();
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