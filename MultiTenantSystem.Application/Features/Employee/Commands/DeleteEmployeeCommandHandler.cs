using MediatR;
using MultiTenantSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Employee.Commands
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, Unit>
    {
        private readonly IEmployeeRepository _repo;
        private readonly IUnitOfWork _uow;
        private readonly ITenantProvider _tenantProvider;

        public DeleteEmployeeCommandHandler(IEmployeeRepository repo, IUnitOfWork uow, ITenantProvider tenantProvider)
        {
            _repo = repo;
            _uow = uow;
            _tenantProvider = tenantProvider;
        }

        public Guid? TenantId => _tenantProvider.GetTenantId();

        public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = await _repo.GetByIdAsync(request.Id);

            if (TenantId != emp?.TenantId)
                throw new UnauthorizedAccessException("User does not belong to the specified tenant");

            if (emp == null || emp.TenantId != request.TenantId)
                throw new UnauthorizedAccessException("Unauthorized or not found");

            _repo.Remove(emp);
            await _uow.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
