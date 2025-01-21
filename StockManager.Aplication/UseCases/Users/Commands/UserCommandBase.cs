using MediatR;

namespace StockManager.UseCases.UseCases.Users.Commands;

public class UserCommandBase : IRequest<long>
{
    public required string Name { get; set; }
    public required string UserName { get; set; }
    public required string Password { get; set; }
}