using MediatR;
using MultiTenantSystem.Application.Interface;
using MultiTenantSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Tenants.Queries
{
    public class GetTenantByIdQueryHandler : IRequestHandler<GetTenantByIdQuery, Tenant>
    {
        private readonly ITenantRepository _tenantRepository;

        public GetTenantByIdQueryHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<Tenant> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
        {
            var tenant = await _tenantRepository.GetByIdAsync(request.TenantId);

            if (tenant == null)
                throw new KeyNotFoundException("Tenant not found");

            return new Tenant
            {
                Id = tenant.Id,
                Name = tenant.Name,
                //Domain = tenant.Domain
            };
        }
    }
}
