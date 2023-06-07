using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.DTOs;

namespace API.Data.Dtos
{
    public class EntryDto
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<TagDto> Tags { get; set; } = new();
        public DateTime CreatedAt { get; set; }
    }

    public class CreateEntryDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}