using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Interface
{
    public interface ITenantProvider
    {
        Guid? GetTenantId();
    }
}
