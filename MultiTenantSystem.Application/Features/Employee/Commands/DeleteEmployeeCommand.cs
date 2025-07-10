using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Employee.Commands
{
    public record DeleteEmployeeCommand(Guid Id, Guid TenantId) : IRequest<Unit>;
}
