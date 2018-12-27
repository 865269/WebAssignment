using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignment.Models;

namespace WebAssignment.Data
{
    public class DbSeeder
    {
        public static void SeedDb(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            CreateData(context);
            CreateUsers(userManager);
        }

        private static void CreateData(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            context.BlogPost.Add(new BlogPost() { Post = "Test1" });

            context.SaveChanges();
        }

        private static void CreateUsers(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "Sam@email.com",
                Email = "Sam@email.com",
            };

            userManager.CreateAsync(user, "Password123!").Wait();
        }
    }
}
