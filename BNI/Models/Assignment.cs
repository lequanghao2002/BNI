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

        public virtual Member? Member { get; set; }
        public virtual Position? Position { get; set; }
        public virtual Term? Term { get; set; }
    }
}
