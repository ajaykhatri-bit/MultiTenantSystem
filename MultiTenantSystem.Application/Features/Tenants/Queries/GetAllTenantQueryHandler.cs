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
    public class GetAllTenantQueryHandler : IRequestHandler<GetAllTenantQuery, List<Tenant>>
    {
        private readonly ITenantRepository _tenantRepository;

        public GetAllTenantQueryHandler(ITenantRepository tenantRepository)
        {
            _tenantRepository = tenantRepository;
        }

        public async Task<List<Tenant>> Handle(GetAllTenantQuery request, CancellationToken cancellationToken)
        {
            var tenants = await _tenantRepository.GetAllAsync();

            return tenants.Select(t => new Tenant
            {
                Id = t.Id,
                Name = t.Name,
                //Domain = t.Domain
            }).ToList();
        }
    }
}
