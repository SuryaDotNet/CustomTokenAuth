using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TokenAuth.Filters;

namespace TokenAuth.Controllers
{

    /// <summary>
    /// Api Consumer Controller
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class ApiConsumerController : Controller
    {

        [HttpGet]
        [Route("VerifyToken")]
        [TokenAuthenticationFilter]
        public ActionResult VerifyToken()
        {
            return new JsonResult ("Hello World" );
        }

    }
}
