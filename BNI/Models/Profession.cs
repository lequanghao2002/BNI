namespace BNI.Models
{
    public partial class Profession
    {
        public Profession()
        {
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public string? Description1 { get; set; }
        public string? Description2 { get; set; }

        public virtual ICollection<Member> Members { get; set; }
    }
}