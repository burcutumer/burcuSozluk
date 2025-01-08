using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        required public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int EntryId { get; set; }
        public int UserId { get; set; }
        required public User User { get; set; }
    }
}