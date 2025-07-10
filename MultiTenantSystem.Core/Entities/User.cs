﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Core.Entities
{
    public class User : IdentityUser<Guid>
    {
        public Guid? TenantId { get; set; }
        public Tenant Tenant { get; set; }
    }
}
