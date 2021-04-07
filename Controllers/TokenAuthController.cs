using System;
using Microsoft.AspNetCore.Mvc;
using TokenAuth.Filters;
using TokenAuth.TokenAuthentication;

namespace TokenAuth.Controllers
{
    /// <summary>
    /// Token Auth Controller
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class TokenAuthController : ControllerBase
    {
        private readonly ITokenManager _tokenManager;

        public TokenAuthController(ITokenManager tokenManager)
        {
            this._tokenManager = tokenManager;
        }

        public IActionResult AuthenticateUser(string user , string pwd)
        {
            if(_tokenManager.AuthenticateUser(user, pwd))
            {
                return Ok(new { Token = _tokenManager.NewToken() });
            }
            else
            {
                return Unauthorized();

            }
        }

    }
}
