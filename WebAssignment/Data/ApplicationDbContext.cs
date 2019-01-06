using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAssignment.Models;

namespace WebAssignment.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebAssignment.Models.BlogPost> BlogPost { get; set; }
        public DbSet<WebAssignment.Models.Comment> Comment { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Comment>()
                .HasOne(b => b.MyBlogPost)
                .WithMany(a => a.CommentList)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
