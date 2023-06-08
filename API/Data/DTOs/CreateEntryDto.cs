using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data.DTOs
{
    public class CreateEntryDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public List<string> Tags { get; set; } = new();
    }
}