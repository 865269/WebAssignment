﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignment.Models
{
    public class BlogPostDetailsViewModel
    {
        public BlogPost BlogPost { get; set; }
        public List<Comment> Comments { get; set; }

        public int BlogPostID { get; set; }
        
        [MinLength(1), MaxLength(50)]
        public string CommentContent { get; set; }
    }
}
