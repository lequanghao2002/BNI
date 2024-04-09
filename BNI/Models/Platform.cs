using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class Platform
    {
        public Platform()
        {
            Contacts = new HashSet<Contact>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; }
    }
}
