using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class Term
    {
        public Term()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
