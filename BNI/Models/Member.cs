namespace BNI.Models
{
    public partial class Member
    {
        public Member()
        {
            Assignments = new HashSet<Assignment>();
            Posts = new HashSet<Post>();
        }

        public int Id { get; set; }
        public int ProfessionId { get; set; }
        public string? Logo { get; set; }
        public string? Avatar { get; set; }
        public string? LinkWeb { get; set; }
        public string? QrCode { get; set; }
        public string? Facebook { get; set; }
        public string? Youtube { get; set; }
        public string? Zalo { get; set; }
        public string? Description { get; set; }
        public string? Pronoun { get; set; }
        public string? Fullname { get; set; }
        public string? Company { get; set; }
        public string? Introducer { get; set; }
        public string? TaxNumber { get; set; }
        public string? TaxAddress { get; set; }
        public string? BillingAddress { get; set; }
        public string? BillingCompany { get; set; }
        public string? BillingEmail { get; set; }
        public string? Sex { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? City { get; set; }
        public string? Provice { get; set; }
        public string? Country { get; set; }
        public string? PostalCode { get; set; }
        public int? UserId { get; set; }
        public string? BusinessSector { get; set; }
        public string? Referrer1 { get; set; }
        public string? Referrer2 { get; set; }
        public string? Position { get; set; }

        public virtual Profession Profession { get; set; } = null!;
        public virtual User? User { get; set; }
        public virtual ICollection<Assignment> Assignments { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
