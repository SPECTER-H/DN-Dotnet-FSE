using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace RetailInventoryAPI.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(
        ActionExecutingContext context)
    {
        var request = context.HttpContext.Request;

        if (!request.Headers.TryGetValue(
                "Authorization",
                out var authorization) ||
            string.IsNullOrWhiteSpace(authorization))
        {
            context.Result = new BadRequestObjectResult(
                "Invalid request - No Auth token");

            return;
        }

        if (!authorization
                .ToString()
                .StartsWith(
                    "Bearer ",
                    StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new BadRequestObjectResult(
                "Invalid request - Token present but Bearer unavailable");
        }
    }
}