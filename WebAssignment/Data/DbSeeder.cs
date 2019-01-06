using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAssignment.Models;

namespace WebAssignment.Data
{
    public class DbSeeder
    {
        public static void SeedDb(ApplicationDbContext context, UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            CreateData(context);
            CreateRoles(roleManager);
            CreateUsers(userManager);
        }

        private static void CreateData(ApplicationDbContext context)
        {

            context.Database.EnsureCreated();

            AddNewBlogPost(new BlogPost() { Post = "Test Post" }, context );

            context.SaveChanges();
        }

        private static void AddNewBlogPost(BlogPost blogPost, ApplicationDbContext context)
        { 
            var existingBlogPost = context.BlogPost.FirstOrDefault(p => p.Post == blogPost.Post);
            if (existingBlogPost == null)
            {
                context.BlogPost.Add(blogPost);
            }
        }

        private static void CreateUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("Member1@email.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Member1@email.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "canPost").Wait();
                }
            }

            if (userManager.FindByNameAsync("Customer1@email.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Customer1@email.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "canComment").Wait();
                }
            }

            if (userManager.FindByNameAsync("Customer2@email.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Customer2@email.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "canComment").Wait();
                }
            }

            if (userManager.FindByNameAsync("Customer3@email.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Customer3@email.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "canComment").Wait();
                }
            }

            if (userManager.FindByNameAsync("Customer4@email.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Customer4@email.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "canComment").Wait();
                }
            }

            if (userManager.FindByNameAsync("Customer5@email.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "Customer5@email.com";

                IdentityResult result = userManager.CreateAsync
                (user, "Password123!").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "canComment").Wait();
                }
            }
        }

        private static void CreateRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("canPost").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "canPost";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }

            if (!roleManager.RoleExistsAsync("canComment").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "canComment";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }
}
