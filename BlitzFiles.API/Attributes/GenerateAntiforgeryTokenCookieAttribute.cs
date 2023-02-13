using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BlitzFiles.API.Attributes
{
    public class GenerateAntiforgeryTokenCookieAttribute : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            var antiforgery = context.HttpContext.RequestServices.GetService<IAntiforgery>();

            if (antiforgery == null)
                throw new NullReferenceException("Antiforgery service is null");

            var token = antiforgery.GetAndStoreTokens(context.HttpContext);

            context.HttpContext.Response.Cookies.Append(
                "RequestVerificationToken",
                token.RequestToken ?? "null",
                new CookieOptions() { HttpOnly = false });
        }
    }
}
