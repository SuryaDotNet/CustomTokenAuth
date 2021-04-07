using System;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using TokenAuth.TokenAuthentication;

namespace TokenAuth.Filters
{
    public class TokenAuthenticationFilter : Attribute, IAuthorizationFilter
    {

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var tokenManager = (ITokenManager)context.HttpContext.RequestServices.GetService(typeof(ITokenManager));
            bool result = true;
            string token = string.Empty;
            if (!context.HttpContext.Request.Headers.ContainsKey("token"))
                result = false;

            if (result)
            {
                token = context.HttpContext.Request.Headers.First(x => x.Key == "token").Value;
                if (!tokenManager.VerifyToken(token))
                    result = false;
            }
            if (!result)
            {
                context.Result = new UnauthorizedObjectResult(HttpStatusCode.Unauthorized);
            }

        }
    }

}