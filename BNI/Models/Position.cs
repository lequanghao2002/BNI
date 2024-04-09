using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class Position
    {
        public Position()
        {
            Assignments = new HashSet<Assignment>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public int? GroupId { get; set; }

        public virtual Group? Group { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}
