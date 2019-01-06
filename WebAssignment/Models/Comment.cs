using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignment.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(50)]
        public String CommentContent { get; set; }

        public virtual BlogPost MyBlogPost { get; set; }
    }
}
