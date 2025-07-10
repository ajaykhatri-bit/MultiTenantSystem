using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.DTOs
{
    public class CreateEmployeeDto
    {
        public string FullName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Position { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string ContactNo { get; set; } = default!;
    }
}
