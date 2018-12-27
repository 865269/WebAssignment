using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignment.Models
{
    public class BlogPostDetailsViewModel
    {
        public BlogPost BlogPost { get; set; }
        public List<Comment> Comments { get; set; }

        public int BlogPostID { get; set; }
        public string CommentContent { get; set; }
    }
}
