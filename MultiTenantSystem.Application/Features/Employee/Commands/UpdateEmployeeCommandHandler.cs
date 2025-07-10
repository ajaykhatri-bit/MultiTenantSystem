using MediatR;
using MultiTenantSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Employee.Commands
{
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly ITenantProvider _tenantProvider;

        public UpdateEmployeeCommandHandler(IEmployeeRepository repo, IUnitOfWork uow, ITenantProvider tenantProvider)
        {
            _repo = repo;
            _uow = uow;
            _tenantProvider = tenantProvider;
        }

        public Guid? TenantId => _tenantProvider.GetTenantId();

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = await _repo.GetByIdAsync(request.Id);

            if(TenantId != emp?.TenantId)
                throw new UnauthorizedAccessException("User does not belong to the specified tenant");

            if (emp == null || emp.TenantId != request.TenantId)
                throw new UnauthorizedAccessException("Unauthorized or not found");

            emp.FullName = request.EmployeeDto.FullName;
            emp.Email = request.EmployeeDto.Email;
            emp.Position = request.EmployeeDto.Position;
            emp.Address = request.EmployeeDto.Address;
            emp.ContactNo = request.EmployeeDto.ContactNo;

            _repo.Update(emp);
            await _uow.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
