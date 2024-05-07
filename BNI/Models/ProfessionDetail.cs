namespace BNI.Models
{
    public partial class ProfessionDetail
    {
        public int Id { get; set; }
        public int? ProfessionId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Icon { get; set; }
        public int? OrderIndex { get; set; }
        public string? TypeColumn { get; set; }
    }
}