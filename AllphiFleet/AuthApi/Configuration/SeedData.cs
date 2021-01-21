using IdentityModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Security.Claims;

namespace AuthApi.Configuration
{
    //ref
    //https://github.com/kevinrjones/SettingUpIdentityServer/blob/master/recordeddemo/identity/ids/SeedData.cs
    public class SeedData
    {
        public static void EnsureRoles(IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!roleManager.RoleExistsAsync
            ("Testrole").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Testrole";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }


            if (!roleManager.RoleExistsAsync
            ("Administrator").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Administrator";
                IdentityResult roleResult = roleManager.CreateAsync(role).Result;
            }
        }
        public static void EnsureUsers(IServiceCollection serviceCollection)
        {
            var serviceProvider = serviceCollection.BuildServiceProvider();
            var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();

            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var alice = userManager.FindByNameAsync("alice").Result;
            if (alice == null)
            {
                alice = new IdentityUser
                {
                    UserName = "alice",
                    Email = "AliceSmith@email.com",
                    EmailConfirmed = true,
                };
                var result = userManager.CreateAsync(alice, "Pass123$").Result;
                
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                var roleResult = userManager.AddToRoleAsync(alice, "admin").Result;

                if (!roleResult.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                #region commentrole
                /* cant have the role yet because user has only just been created here
                 * should you want to check the role:
                 * 
                var roles = userManager.GetRolesAsync(alice).Result;
                if(!roles.Contains("admin"))

                */
                #endregion

                result = userManager.AddClaimsAsync(alice, new Claim[]
                {
                  new Claim(JwtClaimTypes.Name, "Alice Smith"),
                  new Claim(JwtClaimTypes.GivenName, "Alice"),
                  new Claim(JwtClaimTypes.FamilyName, "Smith"),
                  new Claim(JwtClaimTypes.WebSite, "http://alice.com"),
                  //added with AddToRoleAsync
                  //new Claim(JwtClaimTypes.Role, "admin")
                }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                Console.WriteLine("alice created");
            }
            else
            {
                Console.WriteLine("alice already exists");
            }

            var bob = userManager.FindByNameAsync("bob").Result;
            if (bob == null)
            {
                bob = new IdentityUser
                {
                    UserName = "bob",
                    Email = "BobSmith@email.com",
                    EmailConfirmed = true
                };
                var result = userManager.CreateAsync(bob, "Pass123$").Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                result = userManager.AddClaimsAsync(bob, new Claim[]
                {
                    new Claim(JwtClaimTypes.Name, "Bob Smith"),
                    new Claim(JwtClaimTypes.GivenName, "Bob"),
                    new Claim(JwtClaimTypes.FamilyName, "Smith"),
                    new Claim(JwtClaimTypes.WebSite, "http://bob.com"),
                    new Claim("location", "somewhere")
                }).Result;
                if (!result.Succeeded)
                {
                    throw new Exception(result.Errors.First().Description);
                }

                Console.WriteLine("bob created");
            }
            else
            {
                Console.WriteLine("bob already exists");
            }
        }
       
    }
}

