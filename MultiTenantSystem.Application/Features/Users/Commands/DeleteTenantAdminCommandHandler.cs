using MediatR;
using Microsoft.AspNetCore.Identity;
using MultiTenantSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Application.Features.Users.Commands
{
    public class DeleteTenantAdminCommandHandler : IRequestHandler<DeleteTenantAdminCommand, bool>
    {
        private readonly UserManager<User> _userManager;

        public DeleteTenantAdminCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Handle(DeleteTenantAdminCommand request, CancellationToken cancellationToken)
        {
            var admins = await _userManager.GetUsersInRoleAsync("Admin");
            var tenantAdmin = admins.FirstOrDefault(u => u.TenantId == request.TenantId);

            if (tenantAdmin == null) return false;

            var result = await _userManager.DeleteAsync(tenantAdmin);
            return result.Succeeded;
        }
    }
}
