using MediatR;
using MultiTenantSystem.Application.DTOs;
using MultiTenantSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Employee.Queries
{
    public class GetEmployeeQueryHandler : IRequestHandler<GetEmployeeQuery, List<EmployeeDto>>
    {
        private readonly IEmployeeRepository _repo;
        private readonly ITenantProvider _tenantProvider;

        public GetEmployeeQueryHandler(IEmployeeRepository repo, ITenantProvider tenantProvider)
        {
            _repo = repo;
            _tenantProvider = tenantProvider;
        }

        public Guid? TenantId => _tenantProvider.GetTenantId();

        public async Task<List<EmployeeDto>> Handle(GetEmployeeQuery request, CancellationToken cancellationToken)
        {
            var list = await _repo.GetAllAsync();
            return list.Where(x => x.TenantId == TenantId).Select(emp => new EmployeeDto
            {
                Id = emp.Id,
                FullName = emp.FullName,
                Email = emp.Email,
                Position = emp.Position,
                Address = emp.Address,
                ContactNo = emp.ContactNo
            }).ToList();
        }
    }
}
