using AutoMapper;
using StockManager.Aplication.UseCases.PermissionGroups.Responses;
using StockManager.Domain.Entities;

namespace StockManager.Aplication.UseCases.PermissionGroups.Mappers
{
    public class PermissionGroupsMapper : Profile
    {
        public PermissionGroupsMapper() {
            CreateMap<PermissionGroup, PermissionGroupResponse>();
        }
    }
}
