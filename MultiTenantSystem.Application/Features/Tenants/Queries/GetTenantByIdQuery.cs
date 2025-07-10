using MediatR;
using MultiTenantSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Tenants.Queries
{
    public record GetTenantByIdQuery(Guid TenantId) : IRequest<Tenant>;
}
