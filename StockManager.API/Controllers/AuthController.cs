using MediatR;
using Microsoft.AspNetCore.Mvc;
using StockManager.Aplication.Responses;
using StockManager.Aplication.UseCases.Auth.Command;
using StockManager.Aplication.UseCases.Auth.Responses;

namespace StockManager.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthController : ControllerBase
{
    private IMediator _mediator;
    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(GenericResponse<LoginResponse>))]
    public async Task<IActionResult> Login([FromBody] LoginCommand command, CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(command, cancellationToken);
        return response.Success ? Accepted(response) : BadRequest(response);
    }
    
}