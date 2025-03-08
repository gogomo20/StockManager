using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StockManager.Aplication.Responses;
using StockManager.Attributes;
using StockManager.UseCases.UseCases.Users.Queries.Get;

namespace StockManager.Filters;
/// <summary>
/// This filter verifies if the user has the permission to perform the action
/// pass on [Permission("YOUR_PERMISSION")]
/// </summary>
public class PermissionsFilter : IAsyncActionFilter
{
    private readonly IMediator _mediator;
    public PermissionsFilter(IMediator mediator) => _mediator = mediator;
    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var user = context.HttpContext.User;
        if (!user.Identity.IsAuthenticated)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        var userId = long.Parse(user.Claims.FirstOrDefault(x => x.Type == "userId").Value ?? "-1");
        var getPermissionRequest
            = new GetUserPermissions() { Id = userId };
        var userPermissions = await _mediator.Send(getPermissionRequest);
        var permissionAttribute = context
                    .ActionDescriptor
                    .EndpointMetadata
                    .OfType<PermissionAttribute>()
                    .Select(x => x.Permission)
                    .FirstOrDefault();
        if (permissionAttribute != null)
        {
            if (!userPermissions.Contains(permissionAttribute))
            {
                var resultObject = new GenericResponseNoData()
                {
                    Errors = new[] { "You do not have permission to perform this action" }
                };
                context.Result = new ObjectResult(resultObject)
                {
                    StatusCode = StatusCodes.Status403Forbidden
                };
                return;
            }
        }
        await next();
    }
}