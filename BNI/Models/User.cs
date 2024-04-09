using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class User
    {
        public User()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Company { get; set; }
        public string? Password { get; set; }
        public string? Vat { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Zip { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}
