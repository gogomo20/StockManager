using MediatR;
using Microsoft.EntityFrameworkCore;
using StockManager.Domain.Entities;
using StockManager.Repositories;

namespace StockManager.UseCases.UseCases.Users.Queries.Get;

public class GetUserPermissions : IRequest<ICollection<string>>
{
    public long Id { get; set; }

    public class GetUserPermissionsHandler : IRequestHandler<GetUserPermissions, ICollection<string>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetUserPermissionsHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ICollection<string>> Handle(GetUserPermissions request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _unitOfWork.GetRepositoryAsync<User>()
                    .SingleOrDefaultAsync(x => x.Id == request.Id, includes: x => x.Include(_ => _.Permissions));
                if (user == null)
                {
                    throw new KeyNotFoundException($"Not found user Permissions");
                }

                return user.Permissions.Select(_ => _.Name).ToList();
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}