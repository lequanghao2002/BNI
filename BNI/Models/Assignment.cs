using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class Assignment
    {
        public int Id { get; set; }
        public int? MemberId { get; set; }
        public int? TermId { get; set; }
        public int? PositionId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? GroupId { get; set; }
        public string? Fullname { get; set; }
        public string? Avatar { get; set; }
        public string? PositionName { get; set; }
        public string? Company { get; set; }


        public virtual Member? Member { get; set; }
        public virtual Position? Position { get; set; }
        public virtual Term? Term { get; set; }
        public virtual Group? Group { get; set; }
    }
}
