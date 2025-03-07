using Microsoft.AspNetCore.Mvc.Filters;

namespace StockManager.Filters;

public class PermissionsFilter : IAsyncActionFilter
{
    public Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        throw new NotImplementedException();
    }
}