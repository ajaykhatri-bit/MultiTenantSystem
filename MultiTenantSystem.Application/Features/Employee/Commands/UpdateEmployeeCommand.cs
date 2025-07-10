using MediatR;
using MultiTenantSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Employee.Commands
{
    public record UpdateEmployeeCommand(Guid Id, CreateEmployeeDto EmployeeDto, Guid TenantId) : IRequest<Unit>;
}
