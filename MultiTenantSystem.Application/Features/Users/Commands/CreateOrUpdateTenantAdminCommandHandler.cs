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
    public class CreateOrUpdateTenantAdminCommandHandler : IRequestHandler<CreateOrUpdateTenantAdminCommand, Guid>
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;

        public CreateOrUpdateTenantAdminCommandHandler(UserManager<User> userManager, RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<Guid> Handle(CreateOrUpdateTenantAdminCommand request, CancellationToken cancellationToken)
        {
            // Step 1: Check if Tenant Admin exists
            var existingAdmins = await _userManager.GetUsersInRoleAsync("Admin");
            var tenantAdmin = existingAdmins.FirstOrDefault(u => u.TenantId == request.TenantId);

            if (tenantAdmin != null)
            {
                // Step 2: Update existing user
                tenantAdmin.Email = request.Email;
                tenantAdmin.UserName = request.Email;

                var token = await _userManager.GeneratePasswordResetTokenAsync(tenantAdmin);
                await _userManager.ResetPasswordAsync(tenantAdmin, token, request.Password);

                await _userManager.UpdateAsync(tenantAdmin);
                return tenantAdmin.Id;
            }

            // Step 3: Create new admin
            var newAdmin = new User
            {
                Id = Guid.NewGuid(),
                Email = request.Email,
                UserName = request.Email,
                TenantId = request.TenantId
            };

            var result = await _userManager.CreateAsync(newAdmin, request.Password);
            if (!result.Succeeded)
                throw new Exception(string.Join(", ", result.Errors.Select(e => e.Description)));

            // Ensure role exists
            if (!await _roleManager.RoleExistsAsync("Admin"))
                await _roleManager.CreateAsync(new IdentityRole<Guid>("Admin"));

            await _userManager.AddToRoleAsync(newAdmin, "Admin");

            return newAdmin.Id;
        }
    }
}
