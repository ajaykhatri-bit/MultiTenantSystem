using Microsoft.AspNetCore.Http;
using MultiTenantSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Infrastructure.Services
{
    public class TenantProvider  : ITenantProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TenantProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /*public Guid? TenantId
        {
            get
            {
                var tenantClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("TenantId")?.Value;
                if (Guid.TryParse(tenantClaim, out var tenantId))
                    return tenantId;

                return null;
            }
        }*/

        public Guid? GetTenantId()
        {
            var user = _httpContextAccessor.HttpContext?.User;

            if (user == null)
                return null;

            var claim = user.FindFirst("TenantId")?.Value;

            return Guid.TryParse(claim, out var tenantId) ? tenantId : null;
        }
    }
}
