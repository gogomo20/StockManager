using StockManager.Domain.Basis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Domain.Entities
{
    public class PermissionGroup : BaseTable
    {
        public required string Name { get; set; }
        public ICollection<Permission> Permissions { get; set; } = [];

    }
}
