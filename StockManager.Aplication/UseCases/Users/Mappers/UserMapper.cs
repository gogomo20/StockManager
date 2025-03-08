using AutoMapper;
using StockManager.Aplication.UseCases.Users.Commands.Create;
using StockManager.Domain.Entities;
using StockManager.UseCases.UseCases.Users.Commands.Update;
using StockManager.UseCases.UseCases.Users.Responses;

namespace StockManager.Aplication.UseCases.Users.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<UpdateUserCommand, User>();
        CreateMap<User, UserResponse>().ForMember(x => x.Permissions,
                                        opt => opt.
                                                        MapFrom(src => src.Permissions.Select(_ => _.Name).ToList()));
    }
}