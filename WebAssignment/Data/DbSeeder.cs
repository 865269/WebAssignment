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
        public static void SeedDb(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            CreateData(context);
            //CreateUsers(userManager);
            AddUserAndRole(context);
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

        private static bool AddUserAndRole(ApplicationDbContext context)
        {
            RoleManager<IdentityRole> roleManager;
            IdentityRole role = new IdentityRole();
            role.Name = "canPost";
            IdentityResult roleResult = roleManager.CreateAsync(role).Result;



            //IdentityResult ir;
            //var rm = new RoleManager<IdentityRole>
            //    (new RoleStore<IdentityRole>(context));
            //ir = rm.Create(new IdentityRole("canPost"));
            //var um = new UserManager<IdentityUser>
            //    (new UserStore<IdentityUser>(context));
            //var user = new IdentityUser()
            //{
            //    UserName = "Member1@email.com",
            //};
            //ir = um.Create(user, "Password123!");
            //if (ir.Succeeded == false)
            //    return ir.Succeeded;
            //ir = um.AddToRole(user.Id, "canPost");
            //return ir.Succeeded;
        }
    }
}
