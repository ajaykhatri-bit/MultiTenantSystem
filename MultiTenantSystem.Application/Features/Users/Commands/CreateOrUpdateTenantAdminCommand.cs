using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Users.Commands
{
    public record CreateOrUpdateTenantAdminCommand(Guid TenantId, string Email, string Password) : IRequest<Guid>;
}
