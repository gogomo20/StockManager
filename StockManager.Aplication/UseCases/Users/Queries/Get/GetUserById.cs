using MediatR;

using StockManager.UseCases.UseCases.Users.Responses;

namespace StockManager.UseCases.UseCases.Users.Queries.Get;

public class GetUserById : IRequest<UserResponse>
{
    public long Id { get; set; }

    public class GetUserByIdHandler : IRequestHandler<GetUserById, UserResponse>
    {


        public async Task<UserResponse> Handle(GetUserById request, CancellationToken cancellationToken)
        {
            // var user = await _context.Users.FindAsync(request.Id);
            return new UserResponse()
            {
                Id = 1,
                Name = "sdfasdfas",
                UserName = "asdfasdfadsf"
            };
        }
    }
}

