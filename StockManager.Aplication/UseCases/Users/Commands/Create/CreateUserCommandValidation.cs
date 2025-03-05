using FluentValidation;
using StockManager.Repositories;

namespace StockManager.Aplication.UseCases.Users.Commands.Create;

public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateUserCommandValidation(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required");
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email is not valid");
        
    }
}