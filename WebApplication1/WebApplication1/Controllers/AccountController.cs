using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    [HttpPost("register")]

    public IActionResult Register()
    {
        return Ok();
    }
}