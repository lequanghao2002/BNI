using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class PostsCategory
    {
        public PostsCategory()
        {
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
