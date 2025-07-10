using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Core.Entities
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Position { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ContactNo { get; set; } = default!;

    }
}
