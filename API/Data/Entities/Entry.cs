using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    [Table("Entries")]
    public class Entry
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<EntryItem> EntryItems { get; set; } = new();
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}