using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Seed
{
    public class Seeder
    {

        public async static Task Seed(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, PaymentContext appContext)
        {
            await appContext.Database.EnsureCreatedAsync();
            await SeedUser(userManager, appContext);
     

        }

        private static async Task SeedUser(UserManager<User> userManager, PaymentContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var users = SeederHelper<User>.GetData("Merchant.json");

                foreach (var user in users)
                {
                    user.EmailConfirmed = true;
                    user.UserName = user.Email.Split('@')[0];
                    // Ensure email confirmation is appropriate for your scenario
                    if (user.EmailConfirmed)
                    {
                        // Generate a random password or allow users to set their passwords
                        string password = "PaySys2024$";
                        var result = await userManager.CreateAsync(user, password);

                        if (!result.Succeeded)
                        {
                            // Handle errors
                            foreach (var error in result.Errors)
                            {
                                // Log or handle each error appropriately
                                Console.WriteLine($"Error creating user: {error.Description}");
                            }
                        }
                    }
                    else
                    {
                        // Optionally, handle scenarios where email confirmation is required
                        Console.WriteLine($"User {user.UserName} requires email confirmation.");
                    }
                }
            }

        }
    }
}
