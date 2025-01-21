using




    MediatR;
using StockManager.Aplication.Utils;
using StockManager.Domain.Entities;
using StockManager.Persistense.Context;
using StockManager.UseCases.UseCases.Users.Commands;

namespace StockManager.Aplication.UseCases.Users.Commands.Create;

public class CreateUserCommand : UserCommandBase
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly ConnectionContext _context;

        public CreateUserCommandHandler()
        {
            _context = new ConnectionContext();
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = new User()
                {
                    UserName = request.UserName,
                    Name = request.Name,
                    Password = request.Password
                };

                await _context.AddAsync(user, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return user.Id;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}