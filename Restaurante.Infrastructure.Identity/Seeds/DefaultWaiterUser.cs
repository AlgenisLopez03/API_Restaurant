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
    public class DefaultWaiterUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            ApplicationUser WaiterUser = new()
            {
                UserName = "DefaultWaiter",
                FirstName = "Leonardo",
                LastName = "Lopez",
                Email = "LeonardodlssantosLopez@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+1 809-738-4852",
                PhoneNumberConfirmed = true
            };


            if (userManager.Users.All(u => u.Id != WaiterUser.Id))
            {
                var user = await userManager.FindByEmailAsync(WaiterUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(WaiterUser, "Hol@mundo_xd");

                    await userManager.AddToRoleAsync(WaiterUser, Roles.WAITER.ToString());
                }
            }

        }
    }
}
