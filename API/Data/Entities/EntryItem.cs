namespace API.Data.Entities
{
    public class EntryItem
    {
        public int Id { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
        public int EntryId { get; set; }
        public Entry Entry { get; set; } = null!;
    }
}