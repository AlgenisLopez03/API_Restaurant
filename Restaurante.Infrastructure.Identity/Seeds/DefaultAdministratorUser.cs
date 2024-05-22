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
    public class DefaultAdministratorUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser adminUser = new()
            {
                UserName = "DefaultAdmin",
                FirstName = "Algenis",
                LastName = "De los Santos Lopez",
                Email = "algenis.lopez03@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+1 849 272 8012",
                PhoneNumberConfirmed = true
            };


            if (userManager.Users.All(u => u.Id != adminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(adminUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(adminUser, "Hol@mundo_xd");

                    await userManager.AddToRoleAsync(adminUser, Roles.ADMINISTRATOR.ToString());
                }
            }

        }
    }
}
