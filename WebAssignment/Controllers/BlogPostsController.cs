using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAssignment.Data;
using WebAssignment.Models;
using Microsoft.AspNetCore.Authorization;

namespace Assignment.Controllers
{
    public class BlogPostsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BlogPostsController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // GET: BlogPosts
        public async Task<IActionResult> Index()
        {
            return View(await _context.BlogPost.ToListAsync());
        }

        // GET: BlogPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BlogPost blogPost = await _context.BlogPost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            BlogPostDetailsViewModel viewModel = await GetBlogPostDetailsViewModelFromBlogPost(blogPost);

            return View(viewModel);
        }

        private async Task<BlogPostDetailsViewModel> GetBlogPostDetailsViewModelFromBlogPost(BlogPost blogPost)
        {
            BlogPostDetailsViewModel viewModel = new BlogPostDetailsViewModel();

            viewModel.BlogPost = blogPost;

            List<Comment> comments = await _context.Comment
                .Where(m => m.MyBlogPost == blogPost).ToListAsync();

            viewModel.Comments = comments;
            return viewModel;
        }

        [Authorize(Roles = "canComment")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details([Bind("BlogPostID, CommentContent")] BlogPostDetailsViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment();

                comment.CommentContent = viewModel.CommentContent;

                BlogPost blogPost = await _context.BlogPost
                .FirstOrDefaultAsync(m => m.Id == viewModel.BlogPostID);
                if (blogPost == null)
                {
                    return NotFound();
                }

                comment.MyBlogPost = blogPost;
                _context.Comment.Add(comment);
                await _context.SaveChangesAsync();

                viewModel = await GetBlogPostDetailsViewModelFromBlogPost(blogPost);

            }

            return View(viewModel);
        }


        // GET: BlogPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "canPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Post")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        
        // GET: BlogPosts/Edit/5
        [Authorize(Roles = "canPost")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPost.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "canPost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Post")] BlogPost blogPost)
        {
            if (id != blogPost.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogPost);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogPostExists(blogPost.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [Authorize(Roles = "canPost")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPost
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        
        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "canPost")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogPost = await _context.BlogPost.FindAsync(id);
            //var comment = await _context.Comment.Where(x => x.MyBlogPost == blogPost).ToListAsync();
            //var comment = await _context.Comment.FindAsync(id);
            _context.BlogPost.Remove(blogPost);
            //_context.Comment.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPost.Any(e => e.Id == id);
        }
    }
}
