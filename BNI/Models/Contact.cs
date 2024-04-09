using System;
using System.Collections.Generic;

namespace BNI.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Job { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyAddress { get; set; }
        public string? Position { get; set; }
        public string? YearOfExperience { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? PlatformId { get; set; }
        public bool? MemberOfCsj { get; set; }
        public string? SupportInformation { get; set; }

        public virtual Platform? Platform { get; set; }
    }
}
