using Microsoft.AspNetCore.Identity;

namespace WebAppResit.Data;

public class IdentitySeedData
{
    public static async Task Initialize(WebAppResitContext context,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        context.Database.EnsureCreated();

        string adminRole = "Admin";
        string memberRole = "Member";
        string password4all = "P@55word";

        if (await roleManager.FindByNameAsync(adminRole) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        if (await roleManager.FindByNameAsync(memberRole) == null)
        {
            await roleManager.CreateAsync(new IdentityRole(memberRole));
        }

        if (await userManager.FindByNameAsync("admin@chester.ac.uk") == null)
        {
            var user = new IdentityUser
            {
                UserName = "admin@uoc.ac.uk",
                Email = "admin@uoc.ac.uk",
                PhoneNumber = ""

            };
            var result = await userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, adminRole);
            }
        }

        if (await userManager.FindByNameAsync("member@chester.ac.uk")==null)
        {
            var user = new IdentityUser
            {
                UserName = "member@chester.ac.uk",
                Email = "member@chester.ac.uk",
                PhoneNumber = ""
            };
            var result = await userManager.CreateAsync(user);
            if(result.Succeeded)
            {
                await userManager.AddPasswordAsync(user, password4all);
                await userManager.AddToRoleAsync(user, memberRole);
            }
        }
    }
}