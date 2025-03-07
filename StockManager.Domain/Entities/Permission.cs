using StockManager.Domain.Basis;

namespace StockManager.Domain.Entities;

public class Permission : BaseTable
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    
}