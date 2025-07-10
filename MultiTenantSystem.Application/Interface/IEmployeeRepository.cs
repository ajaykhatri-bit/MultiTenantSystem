using MultiTenantSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Interface
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
    }
}
