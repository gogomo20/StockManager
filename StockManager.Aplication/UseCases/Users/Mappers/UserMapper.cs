using AutoMapper;
using StockManager.Aplication.UseCases.Users.Commands.Create;
using StockManager.Domain.Entities;

namespace StockManager.Aplication.UseCases.Users.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserCommand, User>();
    }
}