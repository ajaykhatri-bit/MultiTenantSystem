using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.DTOs
{
    public class LoginDto
    {
        public Guid? TenantId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
