using MediatR;
using MultiTenantSystem.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Employee.Queries
{
    public class GetEmployeeQuery(Guid TenantId) : IRequest<List<EmployeeDto>>;
}
