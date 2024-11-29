using CatalogoCleanArch.API.Models;
using CatalogoCleanArch.Domain.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoCleanArch.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthenticate _authentication;

    public TokenController(IAuthenticate authentication)
    {
        _authentication = authentication ??
            throw new ArgumentNullException(nameof(authentication));
    }

    [HttpPost("LoginUser")]
    public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
    {
        var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

        if (result)
        {
            //return GenerateToken(userInfo);
            return Ok($"User {userInfo.Email} login successfuly");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt");
            return BadRequest(ModelState);
        }
    }
}
