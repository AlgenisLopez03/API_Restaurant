using Microsoft.AspNetCore.Identity;
using Restaurante.Core.Application.Enums;
using Restaurante.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurante.Infrastructure.Identity.Seeds
{
    public class DefaultSuperAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var defaultUser = new ApplicationUser
            {
                UserName = "superadmin",
                Email = "superadmin@localhost",
                FirstName = "Super",
                LastName = "Admin",
                EmailConfirmed = true,
                PhoneNumber = "+1 809 935 0913",
                PhoneNumberConfirmed = true
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);
                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "Hol@mundo_xd");
                    await userManager.AddToRoleAsync(defaultUser, Roles.SUPERADMINISTRATOR.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.ADMINISTRATOR.ToString());
                    await userManager.AddToRoleAsync(defaultUser, Roles.WAITER.ToString());
                }

            }
        }
    }
}
