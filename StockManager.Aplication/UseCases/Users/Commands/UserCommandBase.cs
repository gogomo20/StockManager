using MediatR;

namespace StockManager.UseCases.UseCases.Users.Commands;

public class UserCommandBase : IRequest<long>
{
    public string Name { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}