using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using MultiTenantSystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenantSystem.Infrastructure.Services
{
    public static class SeedData
    {
        public static async Task SeedGlobalAdminAsync(IServiceProvider services)
        {
            using var scope = services.CreateScope();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();

            var adminEmail = "admin@global.com";
            var adminRole = "SuperAdmin";
            var tenantadmin = "Admin";
            var employee = "Employee";

            if (!await roleManager.RoleExistsAsync(adminRole))
                await roleManager.CreateAsync(new IdentityRole<Guid>(adminRole));

            if (await userManager.FindByEmailAsync(adminEmail) is null)
            {
                var user = new User
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true,
                    TenantId = null // Global admin has no tenant
                };

                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, adminRole);
            }

            if (!await roleManager.RoleExistsAsync(tenantadmin))
                await roleManager.CreateAsync(new IdentityRole<Guid>(tenantadmin));

            if (!await roleManager.RoleExistsAsync(employee))
                await roleManager.CreateAsync(new IdentityRole<Guid>(employee));
        }
    }
}
