using MediatR;
using MultiTenantSystem.Application.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Employee.Commands
{
    public class CreateEmployeeCommandHandler : IRequestHandler<CreateEmployeeCommand, Guid>
    {
        private readonly IEmployeeRepository _repo;
        private readonly IUnitOfWork _uow;

        public CreateEmployeeCommandHandler(IEmployeeRepository repo, IUnitOfWork uow)
        {
            _repo = repo;
            _uow = uow;
        }

        public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var emp = new Core.Entities.Employee
            {
                Id = Guid.NewGuid(),
                FullName = request.EmployeeDto.FullName,
                Email = request.EmployeeDto.Email,
                Position = request.EmployeeDto.Position,
                TenantId = request.TenantId,
                Address = request.EmployeeDto.Address,
                ContactNo = request.EmployeeDto.ContactNo,
            };

            await _repo.AddAsync(emp);
            await _uow.SaveChangesAsync();

            return emp.Id;
        }
    }
}
