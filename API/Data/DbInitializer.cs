using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(StoreContext context, RoleManager<UserRole> roleManager, UserManager<User> userManager)
        {
            if (!userManager.Users.Any())
            {
                await roleManager.CreateAsync(new UserRole
                {
                    Name = "admin"
                });

                await roleManager.CreateAsync(new UserRole
                {
                    Name = "member"
                });

                var user = new User
                {
                    NickName = "Bob",
                    UserName = "bob@test.com",
                    Email = "bob@test.com"
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "member");

                var admin = new User
                {
                    NickName = "admin",
                    UserName = "admin@test.com",
                    Email = "admin@test.com"
                };
                await userManager.CreateAsync(admin, "Pa$$w0rd");
                await userManager.AddToRolesAsync(admin, new[] { "Member", "admin" });
            }

            if (context.Tags.Any()) return;

            var tags = new List<Tag>
            {
                new Tag
                {
                    Id = 1,
                    Name = "Mercedes"
                },
                new Tag
                {
                    Id = 2,
                    Name = "Volkswagen"
                },
                 new Tag
                {
                    Id = 3,
                    Name = "Toyota"
                }
            };

            foreach (var tag in tags)
            {
                context.Tags.Add(tag);
            }
            context.SaveChanges();
        }
    }
}