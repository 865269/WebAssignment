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

        public String Post { get; set; }
    }
}
