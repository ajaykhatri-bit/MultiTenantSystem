using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Tenants.Commands
{
    public record CreateTenantCommand(string Name) : IRequest<Guid>;
}
