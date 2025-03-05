using StockManager.Domain.Basis;

namespace StockManager.Domain.Entities;

public class UserPermission : BaseTable
{
    public long UserId { get; set; }
    public long PermissionId { get; set; }
    public virtual Permission Permission { get; set; }
    public virtual User User { get; set; }
}