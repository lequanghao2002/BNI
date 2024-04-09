using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public int? PostCategory { get; set; }
        public string? Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? View { get; set; }
        public int? MemberId { get; set; }

        public virtual Member? Member { get; set; }
        public virtual PostsCategory? PostCategoryNavigation { get; set; }
    }
}
