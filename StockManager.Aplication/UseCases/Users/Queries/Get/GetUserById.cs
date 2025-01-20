using MediatR;
using StockManager.Persistense.Context;
using StockManager.UseCases.UseCases.Users.Responses;

namespace StockManager.UseCases.UseCases.Users.Queries.Get;

public class GetUserById : IRequest<UserResponse>
{
    public long Id { get; set; }

    public class GetUserByIdHandler : IRequestHandler<GetUserById, UserResponse>
    {
        private readonly ConnectionContext _context;

        public GetUserByIdHandler(ConnectionContext context)
        {
            _context = context;
        }

        public async Task<UserResponse> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FindAsync(request.Id);
            return new UserResponse()
            {
                Id = user.Id,
                Name = user.Name,
                UserName = user.UserName
            };
        }
    }
}

