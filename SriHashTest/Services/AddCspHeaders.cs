using System;
using System.Web.Mvc;

namespace SriHashTest.Services
{
    public class AddCspHeaders : ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var nonce = Guid.NewGuid().ToString("n");
            filterContext.Controller.ViewBag.__cspHeaderNonce = nonce;

            filterContext.HttpContext.Response.Headers["Content-Security-Policy"] = $"script-src 'self' 'nonce-{nonce}' https://cdnjs.cloudflare.com/ajax/libs/numeral.js/2.0.6/numeral.min.js; style-src 'self'";
        }
    }
}