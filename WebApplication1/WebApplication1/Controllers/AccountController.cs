using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dtos.UserDtos;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController
    (
        IValidator<RegisterDto> registerValidator,
        UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IMapper mapper
    ) : ControllerBase
{
    [HttpPost("register")]

    public async Task <IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        var validationResult = registerValidator.Validate(registerDto);
        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);
        var user = await userManager.FindByNameAsync(registerDto.UserName);
        if(user is not null)
            return BadRequest("Username already exists");
        user = mapper.Map<AppUser>(registerDto);
        
        var result = await userManager.CreateAsync(user, registerDto.Password);
        if (!result.Succeeded)
            return BadRequest(result.Errors);
        return Ok();
    }
}