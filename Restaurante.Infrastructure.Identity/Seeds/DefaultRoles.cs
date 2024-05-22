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
    public class DefaultRoles
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new(Roles.SUPERADMINISTRATOR.ToString()));
            await roleManager.CreateAsync(new(Roles.ADMINISTRATOR.ToString()));
            await roleManager.CreateAsync(new(Roles.WAITER.ToString()));


        }
    }
}
