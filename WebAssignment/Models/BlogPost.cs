using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAssignment.Models
{
    public class BlogPost
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(500)]
        public String Post { get; set; }

        public virtual List<Comment> CommentList { get; set; }
    }
}
