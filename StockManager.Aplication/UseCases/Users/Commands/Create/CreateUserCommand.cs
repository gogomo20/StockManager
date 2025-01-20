using 
    
    
    
    
    MediatR;
using StockManager.Domain.Entities;
using StockManager.Persistense.Context;

namespace StockManager.UseCases.UseCases.Users.Commands.Create;

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

                await _context.AddAsync(user);
                await _context.SaveChangesAsync();
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