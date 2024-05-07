using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class Group
    {
        public Group()
        {
            Positions = new HashSet<Position>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
