using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class EntryDto
    {
        public int Id { get; set; }
        required public string Nickname { get; set; }
        required public string Title { get; set; }
        required public string Description { get; set; }
        public List<TagDto> Tags { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }

}