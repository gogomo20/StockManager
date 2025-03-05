using AutoMapper;
using




    MediatR;
using StockManager.Aplication.Utils;
using StockManager.Domain.Entities;
using StockManager.Repositories;
using StockManager.UseCases.UseCases.Users.Commands;

namespace StockManager.Aplication.UseCases.Users.Commands.Create;

public class CreateUserCommand : UserCommandBase
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, long>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _mapper.Map<User>(request);
                user.Password = StringUtils.GetBcryptHash(request.Password);
                await _unitOfWork.GetRepositoryAsync<User>().InsertAsync(user);
                await _unitOfWork.CommitAsync();
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